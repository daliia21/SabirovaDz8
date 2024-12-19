using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models2
{
    class TaskManager
    {
        public List<Project> Projects { get; set; } // Список проектов
        public List<TeamMember> Team { get; set; } // Список участников команды

        public TaskManager()
        {
            Projects = new List<Project>();
            Team = new List<TeamMember>();
        }

        // Добавить участника в команду
        public void AddTeamMember(string name)
        {
            Team.Add(new TeamMember(name));
        }

        // Создать новый проект
        public Project CreateProject(string description, DateTime deadline, string initiator, string teamLead)
        {
            var project = new Project(description, deadline, initiator, teamLead);
            Projects.Add(project);
            return project;
        }
    }

}
