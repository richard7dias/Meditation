
namespace MeditationPt.Infra
{
	public class MeditationsDatabaseSettings
	{
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MeditationsCollectionName { get; set; } = null!;
    }
}