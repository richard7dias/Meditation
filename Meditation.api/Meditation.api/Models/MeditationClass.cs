using System;

namespace Meditation.api.Models
{
	public class MeditationClass
	{
		public string _id { get; private set; }

		public int _pageNumber { get; private set; }

		public string _text { get; private set; }

		public string _dateDisplay { get; private set; }

		public string _dateTemp { get; private set; }

		public string _date { get; private set; }

		public string _title { get; private set; }

		public string _verseText { get; private set; }

		public string _verseRef { get; private set; }

        public MeditationClass(int pageNumber, string text, string dateDisplay, string dateTemp, string date, string title, string verseText, string verseRef)
        {
            _id = Guid.NewGuid().ToString();
            _pageNumber = pageNumber;
            _text = text;
            _dateDisplay = dateDisplay;
            _dateTemp = dateTemp;
            _date = date;
            _title = title;
            _verseText = verseText;
            _verseRef = verseRef;
        }

        public void UpdateMeditation(int pageNumber, string text, string dateDisplay, string dateTemp, string date, string title, string verseText, string verseRef)
        {
            _pageNumber = pageNumber;
            _text = text;
            _dateDisplay = dateDisplay;
            _dateTemp = dateTemp;
            _date = date;
            _title = title;
            _verseText = verseText;
            _verseRef = verseRef;
        }
    }
}

