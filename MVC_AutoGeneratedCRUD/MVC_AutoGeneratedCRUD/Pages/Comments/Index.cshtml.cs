﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVC_AutoGeneratedCRUD.Model;

namespace MVC_AutoGeneratedCRUD.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly MVC_AutoGeneratedCRUD.Model.ApplicationDbContext _context;
        // для пейджирования появятся два свойства 
        public int PageSize { get; } = 10;
        public int PageCount { get; private set; }
        public int CurrentPage { get; private set; } // первая страница

        public IndexModel(MVC_AutoGeneratedCRUD.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; } = default!;

        public async Task OnGetAsync(int currentPage=1)
        {
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            // получить кол-во комментов
            int commentsCount = await _context.Comments.CountAsync();

            // получить кол-во страниц (пр-ма посчитает сама, просто поднимутся метаданные)
            PageCount = commentsCount / PageSize;

            if (commentsCount % PageSize != 0)
            {
                PageCount++;
            }

            if (currentPage > PageCount)
            {
                currentPage = PageCount;
            }

            CurrentPage = currentPage;

            // подгружаем клиентов комментариев // то привязываем их между собой, программа сама не может
            // здесь пейджирование
            Comment = await _context.Comments
                // упорядочивание по столбцу - айди (пейджирование возможно только с ним)
                .OrderBy(c => c.Id)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)               
                .Include(c => c.Client).ToListAsync();
        }
    }
}
