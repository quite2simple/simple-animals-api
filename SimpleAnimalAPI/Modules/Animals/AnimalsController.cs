using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAnimalAPI.Common.Pagination;
using SimpleAnimalAPI.Modules.Animals.Contracts;

namespace SimpleAnimalAPI.Modules.Animals
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalsService _animalsService;
        
        public AnimalsController(AnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        [HttpGet]
        public IActionResult GetAnimals([FromQuery] GetAnimalsQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var animals = _animalsService.GetList(query.Offset, query.Limit, query.Detailed);
                var metadata = new PaginationMetadata()
                {
                    Offset = query.Offset,
                    TotalCount = animals.Length
                };
                var hasNext = query.Offset + query.Limit < metadata.TotalCount;
                var hasPrevious = query.Offset > 0;
                // TODO: Fix link calculations
                var links = new PaginationLinks()
                {
                    Current = "api/animals?offset=" + query.Offset + "&limit=" + query.Limit + "&detailed=" + query.Detailed,
                    Previous = hasPrevious ? "api/animals?offset=" + (query.Offset - query.Limit) + "&limit=" + query.Limit + "&detailed=" + query.Detailed : null,
                    Next = hasNext ? "api/animals?offset=" + (query.Offset + query.Limit) + "&limit=" + query.Limit + "&detailed=" + query.Detailed : null,
                    First = "api/animals?offset=0&limit=" + query.Limit + "&detailed=" + query.Detailed,
                    Last = "api/animals?offset=" + (metadata.TotalCount - query.Limit) + "&limit=" + query.Limit + "&detailed=" + query.Detailed
                };
                var paginatedResponse = new PaginatedResponse<AnimalResponse>()
                {
                    Data = new List<AnimalResponse>(animals),
                    Metadata = metadata,
                    Links = links
                };
                return Ok(paginatedResponse);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid query parameters");
            }
        }
    }
}
