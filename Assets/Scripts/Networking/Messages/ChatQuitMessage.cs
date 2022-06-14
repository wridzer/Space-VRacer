using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

namespace ChatClientExample
{
    public class ChatQuitMessage : MessageHeader
    {
		public override NetworkMessageType Type { 
			get {
				return NetworkMessageType.CHAT_QUIT;
			}
		}

		public override void SerializeObject(ref DataStreamWriter writer) {
			// very important to call this first
			base.SerializeObject(ref writer);
		}

		public override void DeserializeObject(ref DataStreamReader reader) {
			// very important to call this first
			base.DeserializeObject(ref reader);
		}
	}
}