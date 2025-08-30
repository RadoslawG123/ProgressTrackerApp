using ProgressTrackerApp.Models;

namespace ProgressTrackerApp.Helpers
{
    public class JSONListHelper
    {
        public static string GetHabitListJSONString(List<Models.HabitCompletion> habits)
        {
            var habitList = new List<Event>();
            foreach (var habit in habits)
            {
                var myHabit = new Event()
                {
                    id = habit.Id,
                    title = habit.Habit.Name,
                    start = habit.Date,
                    allDay = true,
                    color = habit.Habit.BackgroundColor,
                    textColor = habit.Habit.TextColor,
                    extendedProps = new Dictionary<string, int?>
                        {
                            { "categoryId", habit.Habit.CategoryId }
                        }
                };
                habitList.Add(myHabit);
            }
            return System.Text.Json.JsonSerializer.Serialize(habitList);
        }

        public static string GetCategoriesListJSONString(List<Models.Category> categories)
        {
            var categoryList = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                var myCategory = new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    BackgroundColor = category.BackgroundColor,
                    TextColor = category.TextColor
                };
                categoryList.Add(myCategory);
            }
            return System.Text.Json.JsonSerializer.Serialize(categoryList);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public bool allDay { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public Dictionary<string, int?> extendedProps { get; set; }
    }

    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
    }
}