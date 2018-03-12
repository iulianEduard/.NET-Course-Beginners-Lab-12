using MyApp.UI.Managers;
using Synkron.UI.Models.Task;
using System.Web.Mvc;

namespace MyApp.UI.Controllers
{
    public class TaskController : Controller
    {
        #region Attributes

        private readonly TaskManager _taskManager;

        #endregion Attributes

        #region Constructor

        public TaskController(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        #endregion Constructor

        #region Public Methods

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ViewAll()
        {
            var taskList = _taskManager.ViewAllTasks();

            return PartialView("_ViewAll", taskList);
        }

        public ActionResult Create()
        {
            var model = _taskManager.CreateTask();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskUIModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _taskManager.SaveTask(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    _taskManager.SetupTask(model);
                    return View(model);
                }
            }
            catch
            {
                _taskManager.SetupTask(model);
                return View();
            }
        }

        #endregion Public Methods
    }
}