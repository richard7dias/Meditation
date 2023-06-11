using System;
using Meditation.api.Models;

namespace Meditation.infra.Repositories
{
	public interface IMeditationRepository
	{
		void Add(MeditationClass meditation);

		void Update(string id, MeditationClass meditation);

		IEnumerable<MeditationClass> FindMeditation();

		MeditationClass FindId(string id);

		void Remove(string id);
    }
}