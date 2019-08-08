using System;

namespace FitnesCenter.BL.Model
{
    /// <summary>
    /// Делаю не Enumom что бы удобнее было работать с EntityFramework
    /// </summary>
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name gender can't be empty or null.", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
