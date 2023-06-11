using System;
namespace Meditation.api.Meditations.infra.Configurations
{
	public class DatabaseConfig : IDatabaseConfig
	{
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}