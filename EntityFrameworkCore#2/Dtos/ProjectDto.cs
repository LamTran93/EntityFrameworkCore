using EntityFrameworkCore_2.Domain.Models;

namespace EntityFrameworkCore_2.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProjectDto(Project project)
        {
            Id = project.Id;
            Name = project.Name;
        }

        public Project ToProject()
        {
            return new Project
            {
                Id = Id,
                Name = Name
            };
        }

        public Project ToProjectWithoutId()
        {
            return new Project
            {
                Name = Name
            };
        }
    }
}
