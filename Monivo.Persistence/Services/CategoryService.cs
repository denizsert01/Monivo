using AutoMapper;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Application.Abstractions.Services;
using Monivo.Application.DTOs.Categories;
using Monivo.Domain.Entities;

namespace Monivo.Persistence.Services
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

        public async Task AddAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null) return;

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.Id);

            if (category == null) return;

            _mapper.Map(dto, category);

            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }

        async Task<CategoryDto?> ICategoryService.GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDto?>(category);
        }
    }
}
