using System.Collections;
using System.Collections.Generic;
using Unity.Networking.Transport;
using UnityEngine;

namespace ChatClientExample
{
    public class HandshakeResponseMessage : MessageHeader
    {
		public override NetworkMessageType Type { 
			get {
				return NetworkMessageType.HANDSHAKE_RESPONSE;
			}
		}

		public string message;
		public uint networkId;

		public override void SerializeObject(ref DataStreamWriter writer) {
			// very important to call this first
			base.SerializeObject(ref writer);

			writer.WriteFixedString128(message);
			writer.WriteUInt(networkId);
		}

		public override void DeserializeObject(ref DataStreamReader reader) {
			// very important to call this first
			base.DeserializeObject(ref reader);

			message = reader.ReadFixedString128().ToString();
			networkId = reader.ReadUInt();
		}
	}
}