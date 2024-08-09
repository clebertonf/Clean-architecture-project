using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
           var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
        public async Task<CategoryDTO> GetById(int? id)
        {
           var categorie = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categorie);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categorieMap = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categorieMap);
        }
        public async Task Update(CategoryDTO categoryDTO)
        {
            var categorieMap = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(categorieMap);
        }

        public async Task Remove(int? id)
        {
            var categorie = await _categoryRepository.GetByIdAsync(id);
           await  _categoryRepository.RemoveAsync(categorie);
        }
    }
}
