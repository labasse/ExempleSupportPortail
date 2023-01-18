using ExempleSupportPortail.Shared;

namespace ExempleSupportPortail.Server
{
    public class SupportContext
    {
        public List<Area> Areas { get; } = new();
        public List<Status> Statuses { get; } = new();
        public List<User> Users { get; } = new();
        public List<Issue> Issues { get; } = new();

        public void Initialize()
        {
            Statuses.Add(new Status() { Title = "In progress" });
            Statuses.Add(new Status() { Title = "On hold" });
            Statuses.Add(new Status() { Title = "Closed" });

            Areas.Add(new Area() { Title = "IT" });
            Areas.Add(new Area() { Title = "Facilities" });
            Areas.Add(new Area() { Title = "HR" });

            Users.Add(new User() { Name = "John Doe", Login = "jdoe" });

            Issues.Add(new Issue()
            {
                User = Users[0],
                Area = Areas[0],
                Status = Statuses[1],
                Subject = "My computer is broken",
                Description = "I can't turn it on",
                Comment = "Did you check the power cable?"
            });
            Issues.Add(new Issue()
            {
                User = Users[0],
                Area = Areas[1],
                Status = Statuses[0],
                Subject = "The door is broken",
                Description = "I can't open it"
            });
            Issues.Add(new Issue()
            {
                User = Users[0],
                Area = Areas[2],
                Status = Statuses[2],
                Subject = "Leave request",
                Description = "I need to leave for 2 weeks",
                Comment = "I approve this leave request"
            });
        }
    }
}
