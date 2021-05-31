// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.AntiCheatClient
{
	public class ReceiveMessageFromServerOptions
	{
		/// <summary>
		/// The data received
		/// </summary>
		public byte[] Data { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct ReceiveMessageFromServerOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private uint m_DataLengthBytes;
		private System.IntPtr m_Data;

		public byte[] Data
		{
			set
			{
				Helper.TryMarshalSet(ref m_Data, value, out m_DataLengthBytes);
			}
		}

		public void Set(ReceiveMessageFromServerOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = AntiCheatClientInterface.ReceivemessagefromserverApiLatest;
				Data = other.Data;
			}
		}

		public void Set(object other)
		{
			Set(other as ReceiveMessageFromServerOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_Data);
		}
	}
}