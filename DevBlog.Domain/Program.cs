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
            IPost<PortfolioPost>? portfolioPostService = services.GetService<IPost<PortfolioPost>>();


            #region Account Service Debugging

            Console.WriteLine("---Account Service Debugging---");

            Account? testAccount = accountService.CreateAccount(new Account("John", "Doe", "johndoe@example.com", "1234"));
            accountService.CreateAccount(new Account("Benjamin", "Blümchen", "benblü@example.com", "1234"));
            accountService.CreateAccount(new Account("Hans", "Jürgen", "hansjür@example.com", "1234"));
            
            Console.WriteLine("First Name: " + testAccount.FirstName);
            Console.WriteLine("Last Name: " + testAccount.LastName);
            Console.WriteLine("Full Name: " + testAccount.FullName);
            Console.WriteLine("Email: " + testAccount.Email);

            bool updatedSuccess = accountService.UpdateAccount(new Account(testAccount.Id, "Doe", "John", "doejohn@example.com", "12345", true, DateTime.Now, testAccount.CreatedAt, testAccount.Posts));
            Console.WriteLine("\nUpdated: " + updatedSuccess);

            Account? newAccount = accountService.GetAccountByEmail("doejohn@example.com");
            Console.WriteLine("\n-Updated Account");
            Console.WriteLine("First Name: " + newAccount.FirstName);
            Console.WriteLine("Last Name: " + newAccount.LastName);
            Console.WriteLine("Full Name: " + newAccount.FullName);
            Console.WriteLine("Email: " + newAccount.Email);

            List<Account> allAccounts = accountService.GetAccounts();
            Console.WriteLine("\n-All Accounts");
            foreach (Account _account in allAccounts)
            {
                Console.WriteLine(_account.Email);
            }

            bool deletedSuccess = accountService.DeleteAccount(testAccount.Id);
            Console.WriteLine("\nDeleted: " + deletedSuccess);

            Console.WriteLine("\n-All Accounts after delete");
            foreach (Account _account in allAccounts)
            {
                Console.WriteLine(_account.Email);
            }

            #endregion

            #region Category Service Debugging

            //Console.WriteLine("\n---Category Service Debugging---");

            //Category testCategory = categoryService.CreateCategory(new Category("Category1"));
            //Category category = categoryService.GetCategory(testCategory.Id);

            //Console.WriteLine(category.Name);

            //categoryService.UpdateCategory(new Category(testCategory.Id, "Category1Updated", testCategory.Posts, testCategory.CreatedAt));

            //Category updatedCategory = categoryService.GetCategory(testCategory.Id);

            //Console.WriteLine(updatedCategory.Name);

            #endregion

            #region Tag Service Debugging

            //Console.WriteLine("\n---Tag Service Debugging---");

            //Tag testTag = tagService.CreateTag(new Tag("Tag1"));
            //Tag tag = tagService.GetTag(testTag.Id);

            //Console.WriteLine(tag.Name);

            //tagService.UpdateTag(new Tag(testTag.Id, "Tag1Updated", testTag.CreatedAt));
            //Tag updatedTag = tagService.GetTag(testTag.Id);

            //Console.WriteLine(updatedTag.Name);

            #endregion

            #region BlogPost Service Debugging

            //Console.WriteLine("\n---BlogPost Service Debugging---");

            //BlogPost? testBlogPost = blogPostService.CreatePost(new BlogPost(newAccount, "BlogPostTitle", "Hello World!", ["1.png", "2.png"], updatedCategory, [updatedTag]));
            //BlogPost? blogPost = blogPostService.GetPost(testBlogPost.Id);

            //Console.WriteLine("BlogPost Title: " + blogPost.Title);
            //Console.WriteLine("BlogPost Content: " + blogPost.Content);

            #endregion

            #region Comment Service Debugging
            
            //Console.WriteLine("\n---Comment Service Debugging---");

            //Comment testComment = commentService.CreateComment(new Comment(blogPost, "Et eller andet comment.", newAccount));
            //Comment comment = commentService.GetComment(testComment.Id);

            //Console.WriteLine(comment.Id);
            //Console.WriteLine(comment.Content);
            //Console.WriteLine(comment.Author.FullName);

            #endregion

            #region PortfolioPost Service Debugging

            //Console.WriteLine("\n---PortfolioPost Service Debugging---");

            //PortfolioPost? testPortfolioPost = portfolioPostService.CreatePost(new PortfolioPost(newAccount, "PortfolioPostTitle", "Hello World!", ["1.png", "2.png"], updatedCategory, [updatedTag]));
            //PortfolioPost? portfolioPost = portfolioPostService.GetPost(testPortfolioPost.Id);

            //Console.WriteLine("PortfolioPost Title: " + portfolioPost.Title);
            //Console.WriteLine("PortfolioPost Content: " + portfolioPost.Content);

            #endregion
        }
    }
}
