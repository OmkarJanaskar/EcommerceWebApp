using ECommerceAPI.Models;
using ECommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repository.Implementation
{  
        public class CategoryRepository : ICategoryRepository
        {
            private readonly EcommerceDbContext _context;

        public CategoryRepository(EcommerceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            {
                try
                {
                    var categories = await _context.Categories.ToListAsync();
                    foreach (var category in categories)
                    {
                        if (string.IsNullOrEmpty(category.ImageUrl))
                        {
                            category.ImageUrl = "images/Categories/default.png";
                        }
                    }
                    return categories;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching categories: " + ex.Message);
                    throw; // rethrow so controller sees the 500 error
                }
        }

            public async Task<Category> GetCategoryByIdAsync(int id)
            {
                return await _context.Categories.FindAsync(id);
            }

            public async Task<Category> AddCategoryAsync(Category category)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }

            public async Task UpdateCategoryAsync(Category category)
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteCategoryAsync(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<bool> CategoryExistsAsync(int id)
            {
                return await _context.Categories.AnyAsync(e => e.CategoryId == id);
            }
        }
 }

