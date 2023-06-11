using System;
using MongoDB.Driver;

namespace Meditation.api.Meditations.infra.Configurations
{
	public interface IDatabaseConfig
	{
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}