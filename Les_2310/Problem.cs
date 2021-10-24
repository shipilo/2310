namespace Les_2310
{
    public enum Tag
    {
        Системный_сектор = 1,
        Сектор_разработки_и_сопровождения = 2
    }
    class Problem
    {
        public Tag Tag;
        public Person Appointing;
        public Person Appointee;  
        
        public Problem(Tag Tag, Person Appointing, Person Appointee)
        {
            this.Tag = Tag;
            this.Appointing = Appointing;
            this.Appointee = Appointee;
        }
        public override string ToString()
        {
            return $"{Tag}, {Appointing.Name} -> {Appointee.Name}";
        }
    }
}
