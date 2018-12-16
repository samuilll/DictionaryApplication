namespace EnglishDictApp.Web.ViewModels.Settings
{
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Services.Mapping;

    public class SettingViewModel : IMapFrom<Setting>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
