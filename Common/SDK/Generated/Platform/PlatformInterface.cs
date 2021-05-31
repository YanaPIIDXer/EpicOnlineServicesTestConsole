// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Platform
{
	public sealed partial class PlatformInterface : Handle
	{
		public PlatformInterface()
		{
		}

		public PlatformInterface(System.IntPtr innerHandle) : base(innerHandle)
		{
		}

		public const int CountrycodeMaxBufferLen = (CountrycodeMaxLength + 1);

		public const int CountrycodeMaxLength = 4;

		/// <summary>
		/// The most recent version of the <see cref="Initialize" /> API.
		/// </summary>
		public const int InitializeApiLatest = 4;

		/// <summary>
		/// The most recent version of the <see cref="InitializeThreadAffinity" /> API.
		/// </summary>
		public const int InitializeThreadaffinityApiLatest = 1;

		public const int LocalecodeMaxBufferLen = (LocalecodeMaxLength + 1);

		public const int LocalecodeMaxLength = 9;

		public const int OptionsApiLatest = 11;

		/// <summary>
		/// Checks if the app was launched through the Epic Launcher, and relaunches it through the Epic Launcher if it wasn't.
		/// </summary>
		/// <returns>
		/// An <see cref="Result" /> is returned to indicate success or an error.
		/// <see cref="Result.Success" /> is returned if the app is being restarted. You should quit your process as soon as possible.
		/// <see cref="Result.NoChange" /> is returned if the app was already launched through the Epic Launcher, and no action needs to be taken.
		/// <see cref="Result.UnexpectedError" /> is returned if the LauncherCheck module failed to initialize, or the module tried and failed to restart the app.
		/// </returns>
		public Result CheckForLauncherAndRestart()
		{
			var funcResult = Bindings.EOS_Platform_CheckForLauncherAndRestart(InnerHandle);

			return funcResult;
		}

		/// <summary>
		/// Create a single Epic Online Services Platform Instance.
		/// 
		/// The platform instance is used to gain access to the various Epic Online Services.
		/// 
		/// This function returns an opaque handle to the platform instance, and that handle must be passed to <see cref="Release" /> to release the instance.
		/// </summary>
		/// <returns>
		/// An opaque handle to the platform instance.
		/// </returns>
		public static PlatformInterface Create(Options options)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<OptionsInternal, Options>(ref optionsAddress, options);

			var funcResult = Bindings.EOS_Platform_Create(optionsAddress);

			Helper.TryMarshalDispose(ref optionsAddress);

			PlatformInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Achievements Interface.
		/// eos_achievements.h
		/// eos_achievements_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Achievements.AchievementsInterface" /> handle
		/// </returns>
		public Achievements.AchievementsInterface GetAchievementsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetAchievementsInterface(InnerHandle);

			Achievements.AchievementsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// This only will return the value set as the override otherwise <see cref="Result.NotFound" /> is returned.
		/// This is not currently used for anything internally.
		/// eos_ecom.h
		/// <seealso cref="CountrycodeMaxLength" />
		/// </summary>
		/// <param name="localUserId">The account to use for lookup if no override exists.</param>
		/// <param name="outBuffer">The buffer into which the character data should be written. The buffer must be long enough to hold a string of <see cref="CountrycodeMaxLength" />.</param>
		/// <param name="inOutBufferLength">
		/// The size of the OutBuffer in characters.
		/// The input buffer should include enough space to be null-terminated.
		/// When the function returns, this parameter will be filled with the length of the string copied into OutBuffer.
		/// </param>
		/// <returns>
		/// An <see cref="Result" /> that indicates whether the active country code string was copied into the OutBuffer.
		/// <see cref="Result.Success" /> if the information is available and passed out in OutBuffer
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if there is not an override country code for the user.
		/// <see cref="Result.LimitExceeded" /> - The OutBuffer is not large enough to receive the country code string. InOutBufferLength contains the required minimum length to perform the operation successfully.
		/// </returns>
		public Result GetActiveCountryCode(EpicAccountId localUserId, out string outBuffer)
		{
			var localUserIdInnerHandle = System.IntPtr.Zero;
			Helper.TryMarshalSet(ref localUserIdInnerHandle, localUserId);

			System.IntPtr outBufferAddress = System.IntPtr.Zero;
			int inOutBufferLength = CountrycodeMaxLength + 1;
			Helper.TryMarshalAllocate(ref outBufferAddress, inOutBufferLength, out _);

			var funcResult = Bindings.EOS_Platform_GetActiveCountryCode(InnerHandle, localUserIdInnerHandle, outBufferAddress, ref inOutBufferLength);

			Helper.TryMarshalGet(outBufferAddress, out outBuffer);
			Helper.TryMarshalDispose(ref outBufferAddress);

			return funcResult;
		}

		/// <summary>
		/// Get the active locale code that the SDK will send to services which require it.
		/// This returns the override value otherwise it will use the locale code of the given user.
		/// This is used for localization. This follows ISO 639.
		/// eos_ecom.h
		/// <seealso cref="LocalecodeMaxLength" />
		/// </summary>
		/// <param name="localUserId">The account to use for lookup if no override exists.</param>
		/// <param name="outBuffer">The buffer into which the character data should be written. The buffer must be long enough to hold a string of <see cref="LocalecodeMaxLength" />.</param>
		/// <param name="inOutBufferLength">
		/// The size of the OutBuffer in characters.
		/// The input buffer should include enough space to be null-terminated.
		/// When the function returns, this parameter will be filled with the length of the string copied into OutBuffer.
		/// </param>
		/// <returns>
		/// An <see cref="Result" /> that indicates whether the active locale code string was copied into the OutBuffer.
		/// <see cref="Result.Success" /> if the information is available and passed out in OutBuffer
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if there is neither an override nor an available locale code for the user.
		/// <see cref="Result.LimitExceeded" /> - The OutBuffer is not large enough to receive the locale code string. InOutBufferLength contains the required minimum length to perform the operation successfully.
		/// </returns>
		public Result GetActiveLocaleCode(EpicAccountId localUserId, out string outBuffer)
		{
			var localUserIdInnerHandle = System.IntPtr.Zero;
			Helper.TryMarshalSet(ref localUserIdInnerHandle, localUserId);

			System.IntPtr outBufferAddress = System.IntPtr.Zero;
			int inOutBufferLength = LocalecodeMaxLength + 1;
			Helper.TryMarshalAllocate(ref outBufferAddress, inOutBufferLength, out _);

			var funcResult = Bindings.EOS_Platform_GetActiveLocaleCode(InnerHandle, localUserIdInnerHandle, outBufferAddress, ref inOutBufferLength);

			Helper.TryMarshalGet(outBufferAddress, out outBuffer);
			Helper.TryMarshalDispose(ref outBufferAddress);

			return funcResult;
		}

		/// <summary>
		/// Get a handle to the Anti-Cheat Client Interface.
		/// eos_anticheatclient.h
		/// eos_anticheatclient_types.h
		/// </summary>
		/// <returns>
		/// <see cref="AntiCheatClient.AntiCheatClientInterface" /> handle
		/// </returns>
		public AntiCheatClient.AntiCheatClientInterface GetAntiCheatClientInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetAntiCheatClientInterface(InnerHandle);

			AntiCheatClient.AntiCheatClientInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Anti-Cheat Server Interface.
		/// eos_anticheatserver.h
		/// eos_anticheatserver_types.h
		/// </summary>
		/// <returns>
		/// <see cref="AntiCheatServer.AntiCheatServerInterface" /> handle
		/// </returns>
		public AntiCheatServer.AntiCheatServerInterface GetAntiCheatServerInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetAntiCheatServerInterface(InnerHandle);

			AntiCheatServer.AntiCheatServerInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Auth Interface.
		/// eos_auth.h
		/// eos_auth_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Auth.AuthInterface" /> handle
		/// </returns>
		public Auth.AuthInterface GetAuthInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetAuthInterface(InnerHandle);

			Auth.AuthInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Connect Interface.
		/// eos_connect.h
		/// eos_connect_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Connect.ConnectInterface" /> handle
		/// </returns>
		public Connect.ConnectInterface GetConnectInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetConnectInterface(InnerHandle);

			Connect.ConnectInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Ecom Interface.
		/// eos_ecom.h
		/// eos_ecom_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Ecom.EcomInterface" /> handle
		/// </returns>
		public Ecom.EcomInterface GetEcomInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetEcomInterface(InnerHandle);

			Ecom.EcomInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Friends Interface.
		/// eos_friends.h
		/// eos_friends_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Friends.FriendsInterface" /> handle
		/// </returns>
		public Friends.FriendsInterface GetFriendsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetFriendsInterface(InnerHandle);

			Friends.FriendsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Kids Web Service Interface.
		/// eos_kws.h
		/// eos_kws_types.h
		/// </summary>
		/// <returns>
		/// <see cref="KWS.KWSInterface" /> handle
		/// </returns>
		public KWS.KWSInterface GetKWSInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetKWSInterface(InnerHandle);

			KWS.KWSInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Leaderboards Interface.
		/// eos_leaderboards.h
		/// eos_leaderboards_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Leaderboards.LeaderboardsInterface" /> handle
		/// </returns>
		public Leaderboards.LeaderboardsInterface GetLeaderboardsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetLeaderboardsInterface(InnerHandle);

			Leaderboards.LeaderboardsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Lobby Interface.
		/// eos_lobby.h
		/// eos_lobby_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Lobby.LobbyInterface" /> handle
		/// </returns>
		public Lobby.LobbyInterface GetLobbyInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetLobbyInterface(InnerHandle);

			Lobby.LobbyInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Metrics Interface.
		/// eos_metrics.h
		/// eos_metrics_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Metrics.MetricsInterface" /> handle
		/// </returns>
		public Metrics.MetricsInterface GetMetricsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetMetricsInterface(InnerHandle);

			Metrics.MetricsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Mods Interface.
		/// eos_mods.h
		/// eos_mods_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Mods.ModsInterface" /> handle
		/// </returns>
		public Mods.ModsInterface GetModsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetModsInterface(InnerHandle);

			Mods.ModsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get the override country code that the SDK will send to services which require it.
		/// This is not currently used for anything internally.
		/// eos_ecom.h
		/// <seealso cref="CountrycodeMaxLength" />
		/// </summary>
		/// <param name="outBuffer">The buffer into which the character data should be written. The buffer must be long enough to hold a string of <see cref="CountrycodeMaxLength" />.</param>
		/// <param name="inOutBufferLength">
		/// The size of the OutBuffer in characters.
		/// The input buffer should include enough space to be null-terminated.
		/// When the function returns, this parameter will be filled with the length of the string copied into OutBuffer.
		/// </param>
		/// <returns>
		/// An <see cref="Result" /> that indicates whether the override country code string was copied into the OutBuffer.
		/// <see cref="Result.Success" /> if the information is available and passed out in OutBuffer
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.LimitExceeded" /> - The OutBuffer is not large enough to receive the country code string. InOutBufferLength contains the required minimum length to perform the operation successfully.
		/// </returns>
		public Result GetOverrideCountryCode(out string outBuffer)
		{
			System.IntPtr outBufferAddress = System.IntPtr.Zero;
			int inOutBufferLength = CountrycodeMaxLength + 1;
			Helper.TryMarshalAllocate(ref outBufferAddress, inOutBufferLength, out _);

			var funcResult = Bindings.EOS_Platform_GetOverrideCountryCode(InnerHandle, outBufferAddress, ref inOutBufferLength);

			Helper.TryMarshalGet(outBufferAddress, out outBuffer);
			Helper.TryMarshalDispose(ref outBufferAddress);

			return funcResult;
		}

		/// <summary>
		/// Get the override locale code that the SDK will send to services which require it.
		/// This is used for localization. This follows ISO 639.
		/// eos_ecom.h
		/// <seealso cref="LocalecodeMaxLength" />
		/// </summary>
		/// <param name="outBuffer">The buffer into which the character data should be written. The buffer must be long enough to hold a string of <see cref="LocalecodeMaxLength" />.</param>
		/// <param name="inOutBufferLength">
		/// The size of the OutBuffer in characters.
		/// The input buffer should include enough space to be null-terminated.
		/// When the function returns, this parameter will be filled with the length of the string copied into OutBuffer.
		/// </param>
		/// <returns>
		/// An <see cref="Result" /> that indicates whether the override locale code string was copied into the OutBuffer.
		/// <see cref="Result.Success" /> if the information is available and passed out in OutBuffer
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.LimitExceeded" /> - The OutBuffer is not large enough to receive the locale code string. InOutBufferLength contains the required minimum length to perform the operation successfully.
		/// </returns>
		public Result GetOverrideLocaleCode(out string outBuffer)
		{
			System.IntPtr outBufferAddress = System.IntPtr.Zero;
			int inOutBufferLength = LocalecodeMaxLength + 1;
			Helper.TryMarshalAllocate(ref outBufferAddress, inOutBufferLength, out _);

			var funcResult = Bindings.EOS_Platform_GetOverrideLocaleCode(InnerHandle, outBufferAddress, ref inOutBufferLength);

			Helper.TryMarshalGet(outBufferAddress, out outBuffer);
			Helper.TryMarshalDispose(ref outBufferAddress);

			return funcResult;
		}

		/// <summary>
		/// Get a handle to the Peer-to-Peer Networking Interface.
		/// eos_p2p.h
		/// eos_p2p_types.h
		/// </summary>
		/// <returns>
		/// <see cref="P2P.P2PInterface" /> handle
		/// </returns>
		public P2P.P2PInterface GetP2PInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetP2PInterface(InnerHandle);

			P2P.P2PInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the PlayerDataStorage Interface.
		/// eos_playerdatastorage.h
		/// eos_playerdatastorage_types.h
		/// </summary>
		/// <returns>
		/// <see cref="PlayerDataStorage.PlayerDataStorageInterface" /> handle
		/// </returns>
		public PlayerDataStorage.PlayerDataStorageInterface GetPlayerDataStorageInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetPlayerDataStorageInterface(InnerHandle);

			PlayerDataStorage.PlayerDataStorageInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Presence Interface.
		/// eos_presence.h
		/// eos_presence_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Presence.PresenceInterface" /> handle
		/// </returns>
		public Presence.PresenceInterface GetPresenceInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetPresenceInterface(InnerHandle);

			Presence.PresenceInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Reports Interface.
		/// eos_reports.h
		/// eos_reports_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Reports.ReportsInterface" /> handle
		/// </returns>
		public Reports.ReportsInterface GetReportsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetReportsInterface(InnerHandle);

			Reports.ReportsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Sanctions Interface.
		/// eos_sanctions.h
		/// eos_sanctions_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Sanctions.SanctionsInterface" /> handle
		/// </returns>
		public Sanctions.SanctionsInterface GetSanctionsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetSanctionsInterface(InnerHandle);

			Sanctions.SanctionsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Sessions Interface.
		/// eos_sessions.h
		/// eos_sessions_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Sessions.SessionsInterface" /> handle
		/// </returns>
		public Sessions.SessionsInterface GetSessionsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetSessionsInterface(InnerHandle);

			Sessions.SessionsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the Stats Interface.
		/// eos_stats.h
		/// eos_stats_types.h
		/// </summary>
		/// <returns>
		/// <see cref="Stats.StatsInterface" /> handle
		/// </returns>
		public Stats.StatsInterface GetStatsInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetStatsInterface(InnerHandle);

			Stats.StatsInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the TitleStorage Interface.
		/// eos_titlestorage.h
		/// eos_titlestorage_types.h
		/// </summary>
		/// <returns>
		/// <see cref="TitleStorage.TitleStorageInterface" /> handle
		/// </returns>
		public TitleStorage.TitleStorageInterface GetTitleStorageInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetTitleStorageInterface(InnerHandle);

			TitleStorage.TitleStorageInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the UI Interface.
		/// eos_ui.h
		/// eos_ui_types.h
		/// </summary>
		/// <returns>
		/// <see cref="UI.UIInterface" /> handle
		/// </returns>
		public UI.UIInterface GetUIInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetUIInterface(InnerHandle);

			UI.UIInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Get a handle to the UserInfo Interface.
		/// eos_userinfo.h
		/// eos_userinfo_types.h
		/// </summary>
		/// <returns>
		/// <see cref="UserInfo.UserInfoInterface" /> handle
		/// </returns>
		public UserInfo.UserInfoInterface GetUserInfoInterface()
		{
			var funcResult = Bindings.EOS_Platform_GetUserInfoInterface(InnerHandle);

			UserInfo.UserInfoInterface funcResultReturn;
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Initialize the Epic Online Services SDK.
		/// 
		/// Before calling any other function in the SDK, clients must call this function.
		/// 
		/// This function must only be called one time and must have a corresponding <see cref="Shutdown" /> call.
		/// </summary>
		/// <param name="options">- The initialization options to use for the SDK.</param>
		/// <returns>
		/// An <see cref="Result" /> is returned to indicate success or an error.
		/// <see cref="Result.Success" /> is returned if the SDK successfully initializes.
		/// <see cref="Result.AlreadyConfigured" /> is returned if the function has already been called.
		/// <see cref="Result.InvalidParameters" /> is returned if the provided options are invalid.
		/// </returns>
		public static Result Initialize(InitializeOptions options)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<InitializeOptionsInternal, InitializeOptions>(ref optionsAddress, options);

			var funcResult = Bindings.EOS_Initialize(optionsAddress);

			Helper.TryMarshalDispose(ref optionsAddress);

			return funcResult;
		}

		/// <summary>
		/// Release an Epic Online Services platform instance previously returned from <see cref="Create" />.
		/// 
		/// This function should only be called once per instance returned by <see cref="Create" />. Undefined behavior will result in calling it with a single instance more than once.
		/// Typically only a single platform instance needs to be created during the lifetime of a game.
		/// You should release each platform instance before calling the <see cref="Shutdown" /> function.
		/// </summary>
		public void Release()
		{
			Bindings.EOS_Platform_Release(InnerHandle);
		}

		/// <summary>
		/// Set the override country code that the SDK will send to services which require it.
		/// This is not currently used for anything internally.
		/// eos_ecom.h
		/// <seealso cref="CountrycodeMaxLength" />
		/// </summary>
		/// <returns>
		/// An <see cref="Result" /> that indicates whether the override country code string was saved.
		/// <see cref="Result.Success" /> if the country code was overridden
		/// <see cref="Result.InvalidParameters" /> if you pass an invalid country code
		/// </returns>
		public Result SetOverrideCountryCode(string newCountryCode)
		{
			var newCountryCodeAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet(ref newCountryCodeAddress, newCountryCode);

			var funcResult = Bindings.EOS_Platform_SetOverrideCountryCode(InnerHandle, newCountryCodeAddress);

			Helper.TryMarshalDispose(ref newCountryCodeAddress);

			return funcResult;
		}

		/// <summary>
		/// Set the override locale code that the SDK will send to services which require it.
		/// This is used for localization. This follows ISO 639.
		/// eos_ecom.h
		/// <seealso cref="LocalecodeMaxLength" />
		/// </summary>
		/// <returns>
		/// An <see cref="Result" /> that indicates whether the override locale code string was saved.
		/// <see cref="Result.Success" /> if the locale code was overridden
		/// <see cref="Result.InvalidParameters" /> if you pass an invalid locale code
		/// </returns>
		public Result SetOverrideLocaleCode(string newLocaleCode)
		{
			var newLocaleCodeAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet(ref newLocaleCodeAddress, newLocaleCode);

			var funcResult = Bindings.EOS_Platform_SetOverrideLocaleCode(InnerHandle, newLocaleCodeAddress);

			Helper.TryMarshalDispose(ref newLocaleCodeAddress);

			return funcResult;
		}

		/// <summary>
		/// Tear down the Epic Online Services SDK.
		/// 
		/// Once this function has been called, no more SDK calls are permitted; calling anything after <see cref="Shutdown" /> will result in undefined behavior.
		/// </summary>
		/// <returns>
		/// An <see cref="Result" /> is returned to indicate success or an error.
		/// <see cref="Result.Success" /> is returned if the SDK is successfully torn down.
		/// <see cref="Result.NotConfigured" /> is returned if a successful call to <see cref="Initialize" /> has not been made.
		/// <see cref="Result.UnexpectedError" /> is returned if <see cref="Shutdown" /> has already been called.
		/// </returns>
		public static Result Shutdown()
		{
			var funcResult = Bindings.EOS_Shutdown();

			return funcResult;
		}

		/// <summary>
		/// Notify the platform instance to do work. This function must be called frequently in order for the services provided by the SDK to properly
		/// function. For tick-based applications, it is usually desireable to call this once per-tick.
		/// </summary>
		public void Tick()
		{
			Bindings.EOS_Platform_Tick(InnerHandle);
		}
	}
}