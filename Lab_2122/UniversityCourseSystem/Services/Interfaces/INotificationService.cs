using Lab_2122.UniversityCourseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2122.UniversityCourseSystem.Services.Interfaces
{
    public interface INotificationService
    {
        void NotifyStudentEnrolled(Student student, Course course);
        void NotifyGradePublished(Student student, Grade grade);

    }
}
