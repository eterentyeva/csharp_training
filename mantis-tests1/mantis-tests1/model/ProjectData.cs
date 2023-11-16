using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData
    {
        public ProjectData() { }
        public ProjectData(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compResult = this.Name.CompareTo(other.Name);

            if (compResult != 0)
            {
                return compResult;
            }
            else
            {
                return Name.CompareTo(other.Name);
            }

        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name.Equals(other.Name) && Name.Equals(other.Name);
        }

        override public int GetHashCode()
        {
            return Name.GetHashCode() + Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + Name
                + "\ndescription = " + Description;
        }
    }
}
