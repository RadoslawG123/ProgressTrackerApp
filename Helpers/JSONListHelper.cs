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
                    start = habit.Date,
                    end = habit.Date,
                    //resourceId = 
                    description = habit.Habit.Description
                };
                habitList.Add(myHabit);
            }
            return System.Text.Json.JsonSerializer.Serialize(habitList);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        //public string resourceId { get; set; }
        public string description { get; set; }
    }

    public class Resource 
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
