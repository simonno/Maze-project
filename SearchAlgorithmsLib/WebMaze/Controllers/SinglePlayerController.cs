using MazeLib;
using System.Web.Http;
using System.Web.Http.Description;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class SinglePlayerController : ApiController
    {
        ISinglePlayerModel model = new SinglePlayerModel();

        [HttpGet]
        [ResponseType(typeof(Maze))]
        public Maze Generate(string mazeName, int rows, int cols)
        {
            return model.GenerateMaze(mazeName, rows, cols);
        }

        [Route("Solve/{name}/{type}")]
        [ResponseType(typeof(MazeSolution))]
        public MazeSolution Solve(string mazeName, int typeOfSearch)
        {
            return model.Solve(mazeName, typeOfSearch);
        }
    }
}
