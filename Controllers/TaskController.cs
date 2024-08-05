using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static List<TaskItem> Tasks = new List<TaskItem>();

    [HttpGet]
    public IEnumerable<TaskItem> Get()
    {
        return Tasks;
    }

    [HttpPost]
    public ActionResult<TaskItem> Post([FromBody] TaskItem task)
    {
        Tasks.Add(task);
        return task;
    }

    [HttpPut("{id}")]
    public ActionResult<TaskItem> Put(string id, [FromBody] TaskItem updatedTask)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        task.Text = updatedTask.Text;
        task.Completed = updatedTask.Completed;
        return task;
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        Tasks.Remove(task);
        return NoContent();
    }
}

public class TaskItem
{
    public string Id { get; set; }
    public string Text { get; set; }
    public bool Completed { get; set; }
}
