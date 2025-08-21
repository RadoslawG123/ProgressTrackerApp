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
                    backgroundColor = "green",
                    borderColor = "green",
                    //description = habit.Habit.Description
                };
                habitList.Add(myHabit);
            }
            return System.Text.Json.JsonSerializer.Serialize(habitList);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public bool allDay { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        //public string description { get; set; }
    }

    public class Resource 
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
