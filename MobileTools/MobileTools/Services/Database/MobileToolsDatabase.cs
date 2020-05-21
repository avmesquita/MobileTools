using MobileTools.Extensions;
using MobileTools.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileTools.Services.Database
{
	public class MobileToolsDatabase
	{
		static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
		{
			return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		});

		static SQLiteAsyncConnection Database => lazyInitializer.Value;
		static bool initialized = false;

		public MobileToolsDatabase()
		{
			InitializeAsync().SafeFireAndForget(false);
		}

		async Task InitializeAsync()
		{
			if (!initialized)
			{
				if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UserConfiguration).Name))
				{
					await Database.CreateTablesAsync(CreateFlags.None, typeof(UserConfiguration)).ConfigureAwait(false);
					initialized = true;
				}
			}
		}

		#region [ GENERAL ]

		public void CleanLocalDatabase()
		{
			Database.DropTableAsync(Database.TableMappings.FirstOrDefault(m => m.MappedType.Name == typeof(UserConfiguration).Name));
			Database.CreateTablesAsync(CreateFlags.None, typeof(UserConfiguration)).ConfigureAwait(false);
			initialized = true;
		}

		#endregion

		#region [ USER CONFIGURATION ]

		public Task<UserConfiguration> GetUserConfigurationAsync()
		{
			return Database.Table<UserConfiguration>().FirstOrDefaultAsync();
		}


		public Task<int> SaveUserConfigurationAsync(UserConfiguration item)
		{
			var user = this.GetUserConfigurationAsync().Result;

			if (user != null)
			{
				item.Id = user.Id;
				item.Guid = user.Guid;

				return Database.UpdateAsync(item);
			}
			else
			{
				return Database.InsertAsync(item);
			}
		}

		public Task<int> DeleteUserConfigurationAsync(UserConfiguration item)
		{
			return Database.DeleteAsync(item);
		}

		#endregion
	}
}
