﻿using Idk.Application.Dependencies;
using Idk.Application.Dtos.Task;
using Idk.Application.Model;

namespace Idk.Application.Mapper.Task;

[DefaultTransientImplementation]
public class TaskMapper : ITaskMapper
{
    public Domain.Models.Task Map(int? subjectId, int userId, TaskDto source)
    {
        return new Domain.Models.Task
        {
            Name = source.Name,
            Description = source.Description,
            Grade = source.Grade,
            Deadline = source.Deadline,
            Theme = source.Theme,
            Status = source.Status,
            SubjectId = subjectId,
            UserId = userId
        };
    }

    public void Map(int? subjectId, TaskDto source, Domain.Models.Task destination)
    {
        destination.Name = source.Name;
        destination.SubjectId = subjectId;
        destination.Description = source.Description;
        destination.Deadline = source.Deadline;
        destination.Grade = source.Grade;
        destination.Theme = source.Theme;
        destination.Status = source.Status;
    }

    public TaskModel Map(Domain.Models.Task source)
    {
        return new TaskModel
        {
            Name = source.Name,
            Description = source.Description,
            Deadline = source.Deadline,
            Theme = source.Theme,
            Grade = source.Grade,
            Status = source.Status,
            Id = source.Id,
            SubjectId = source.SubjectId
        };
    }
}