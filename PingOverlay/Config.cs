namespace PingOverlay
{
    public class Config
    {
        public string Ip { get; set; }
        public string Interval { get; set; }
        public string Bytes { get; set; }
        public string Ttl { get; set; }
        public string Timeout { get; set; }
        public string FontSize { get; set; }
        public string TextColor { get; set; }
        public string OutlineWidth { get; set; }
        public string OutlineForeColor { get; set; }
        public bool? ShowBorder { get; set; }
        public string PosX { get; set; }
        public string PosY { get; set; }

        public void ApplyDefaultToNulls()
        {
            Ip = Ip ?? "0.0.0.0";
            Interval = Interval ?? "1";
            Bytes = Bytes ?? "64";
            Ttl = Ttl ?? "255";
            Timeout = Timeout ?? "999";
            FontSize = FontSize ?? "32";
            TextColor = TextColor ?? "#FFFFFF";
            OutlineWidth = OutlineWidth ?? "2";
            OutlineForeColor = OutlineForeColor ?? "#000000";
            ShowBorder = ShowBorder ?? true;
            PosX = PosX ?? "0";
            PosY = PosY ?? "0";
        }
    }
}