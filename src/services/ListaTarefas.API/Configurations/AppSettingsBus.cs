namespace ListaTarefas.API.Configurations
{
    public class AppSettingsBus
    {
        public bool Enabled { get; set; }
        public int PrefetchCount { get; set; }
        public int RetryCount { get; set; }
        public int RetryInterval { get; set; }
        public string Queue { get; set; }
    }
}
