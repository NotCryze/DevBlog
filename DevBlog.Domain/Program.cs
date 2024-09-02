using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using DevBlog.Domain.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider services = new ServiceCollection()
                .AddSingleton<IAccountRepository, AccountRepository>()
                .AddSingleton<ICategoryRepository, CategoryRepository>()
                .AddSingleton<ICommentRepository, CommentRepository>()
                .AddSingleton<ITagRepository, TagRepository>()
                .AddSingleton<IPost<BlogPost>, BlogPostRepository>()
                .AddSingleton<IPost<PortfolioPost>, PortfolioPostRepository>()
                .BuildServiceProvider();

            IAccountRepository? accountService = services.GetService<IAccountRepository>();
            ICategoryRepository? categoryService = services.GetService<ICategoryRepository>();
            ICommentRepository? commentService = services.GetService<ICommentRepository>();
            ITagRepository? tagService = services.GetService<ITagRepository>();
            IPost<BlogPost>? blogPostService = services.GetService<IPost<BlogPost>>();


            #region Account Service Debugging

            Console.WriteLine("\n---Account Service Debugging---");

            Account? account = accountService.CreateAccount(new Account("Hans", "Jürgen", "Hans@gg.com", "1234"));
            Account? account2 = accountService.CreateAccount(new Account("Hans", "Jürgen", "Hans@gge.com", "1234"));
            Account? account3 = accountService.CreateAccount(new Account("Hans", "Jürgen", "Hans@ggr.com", "1234"));
            Console.WriteLine(account.FirstName);
            Console.WriteLine(account.LastName);
            Console.WriteLine(account.FullName);

            bool updatedSuccess = accountService.UpdateAccount(new Account(account.Id, "Harald", "Crack", "Hansi@gg.de", "12345", true, account.UpdatedAt, account.CreatedAt, account.Posts));
            Console.WriteLine(updatedSuccess);

            Account? newAccount = accountService.GetAccountByEmail("Hansi@gg.de");
            Console.WriteLine("\nUpdated Account");
            Console.WriteLine(newAccount.FirstName);
            Console.WriteLine(newAccount.LastName);
            Console.WriteLine(newAccount.FullName);

            List<Account> allAccounts = accountService.GetAccounts();
            Console.WriteLine("\nAll Accounts");
            foreach (Account _account in allAccounts)
            {
                Console.WriteLine(_account.Email);
            }

            bool deletedSuccess = accountService.DeleteAccount(account.Id);
            Console.WriteLine("\nDeleted: " + deletedSuccess);

            Console.WriteLine("\nAll Accounts after delete");
            foreach (Account _account in allAccounts)
            {
                Console.WriteLine(_account.Email);
            }

            #endregion

            #region Category Service Debugging

            Console.WriteLine("\n---Category Service Debugging---");

            Category testCategory = categoryService.CreateCategory(new Category("Category1"));
            Category category = categoryService.GetCategory(testCategory.Id);

            Console.WriteLine(category.Name);

            categoryService.UpdateCategory(new Category(testCategory.Id, "Category1Updated", testCategory.Posts, testCategory.CreatedAt));

            Category updatedCategory = categoryService.GetCategory(testCategory.Id);

            Console.WriteLine(updatedCategory.Name);

            #endregion

            #region Tag Service Debugging

            Console.WriteLine("\n---Tag Service Debugging---");

            Tag testTag = tagService.CreateTag(new Tag("Tag1"));
            Tag tag = tagService.GetTag(testTag.Id);

            Console.WriteLine(tag.Name);

            tagService.UpdateTag(new Tag(testTag.Id, "Tag1Updated", testTag.CreatedAt));
            Tag updatedTag = tagService.GetTag(testTag.Id);

            Console.WriteLine(updatedTag.Name);

            #endregion

            #region Comment Service Debugging

            //commentService.CreateComment(new Comment());

            #endregion

            #region BlogPost Service Debugging

            Console.WriteLine("\n---BlogPost Service Debugging---");

            BlogPost? testBlogPost = blogPostService.CreatePost(new BlogPost(newAccount, "BlogPostTitle", "Hello World!", ["1.png", "2.png"], updatedCategory, [updatedTag]));
            BlogPost? blogPost = blogPostService.GetPost(testBlogPost.Id);

            Console.WriteLine("BlogPost Title: " + blogPost.Title);
            Console.WriteLine("BlogPost Content: " + blogPost.Content);

            #endregion

        }
    }
}
