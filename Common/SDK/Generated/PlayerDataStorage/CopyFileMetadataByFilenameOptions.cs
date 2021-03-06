// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.PlayerDataStorage
{
	/// <summary>
	/// Input data for the CopyFileMetadataByFilename function
	/// </summary>
	public class CopyFileMetadataByFilenameOptions
	{
		/// <summary>
		/// The Product User ID of the local user who is requesting file metadata
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The file's name to get data for
		/// </summary>
		public string Filename { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CopyFileMetadataByFilenameOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_Filename;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.TryMarshalSet(ref m_LocalUserId, value);
			}
		}

		public string Filename
		{
			set
			{
				Helper.TryMarshalSet(ref m_Filename, value);
			}
		}

		public void Set(CopyFileMetadataByFilenameOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = PlayerDataStorageInterface.CopyfilemetadatabyfilenameoptionsApiLatest;
				LocalUserId = other.LocalUserId;
				Filename = other.Filename;
			}
		}

		public void Set(object other)
		{
			Set(other as CopyFileMetadataByFilenameOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_LocalUserId);
			Helper.TryMarshalDispose(ref m_Filename);
		}
	}
}