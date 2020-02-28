using AutoMapper;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebServices.Models.InputModels.Categories;
using WebServices.Models.OutputModels.Categories;

namespace WebServices.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        public async Task<IHttpActionResult> GetAll()
        {
            var categories = await categoryRepository.GetAllAsync();

            if (categories == null || !categories.Any())
                return NotFound();

            var result = mapper.Map<List<CategoryOutputModel>>(categories);

            return Ok(result);
        }

        public async Task<IHttpActionResult> Post (CategoryInputModel inputModel)
        {
            if (inputModel == null)
                throw new ArgumentException("inputModel can't be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category()
            {
                Name = inputModel.Name,
            };

            var result = await categoryRepository.SaveAsync(category);

            if (!result)
                throw new OperationCanceledException("Error when saved!");

            return Ok();
        }

        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] CategoryInputModel inputModel)
        {
            if (inputModel == null)
                throw new ArgumentException("inputModel can't be null");

            if (!ModelState.IsValid)
                return BadRequest();

            var category = await categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            category.Name = inputModel.Name;

            var result = await categoryRepository.SaveAsync(category);

            if (!result)
                throw new OperationCanceledException("Error when saved!");

            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if (category == null) return BadRequest();

            var result = await categoryRepository.DeleteAsync(category);

            if (!result)
                throw new OperationCanceledException("error when deleted category!");

            return Ok();
        }
    }
}
