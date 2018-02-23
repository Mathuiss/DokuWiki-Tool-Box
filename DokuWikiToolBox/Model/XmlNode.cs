namespace Model
{
    public struct XmlNode
    {
        private string type;
        private string value;

        public XmlNode(string type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public string Type { get => type; set => type = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
