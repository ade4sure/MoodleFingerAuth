namespace CBTAuth.Dtos
{
    static class GlobalClass
    {
        private static string _baseURL = "";
        private static string _hallName = "";
        private static string _cCode = "";

        public static string BaseURL
        {
            get { return _baseURL; }
            set { _baseURL = value; }
        }
        public static string HallName
        {
            get { return _hallName; }
            set { _hallName = value; }
        }
        public static string CCode
        {
            get { return _cCode; }
            set { _cCode = value; }
        }
    }
}
