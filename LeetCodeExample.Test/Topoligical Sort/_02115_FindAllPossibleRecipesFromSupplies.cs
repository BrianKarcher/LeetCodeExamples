using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You have information about n different recipes.You are given a string array recipes and a 2D string array ingredients.The ith recipe has the name recipes[i], and you can create it if you have all the needed ingredients from ingredients[i]. Ingredients to a recipe may need to be created from other recipes, i.e., ingredients[i] may contain a string that is in recipes.
    //You are also given a string array supplies containing all the ingredients that you initially have, and you have an infinite supply of all of them.
    //Return a list of all the recipes that you can create. You may return the answer in any order.

    //Note that two recipes may contain each other in their ingredients.
    /// </summary>
    public class _02115_FindAllPossibleRecipesFromSupplies
    {
        Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
        Dictionary<string, bool> valid;
        HashSet<string> suppliesHash;
        HashSet<string> recipesHash;

        public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            suppliesHash = supplies.ToHashSet();
            recipesHash = recipes.ToHashSet();
            valid = new Dictionary<string, bool>();
            // Build adjacency List
            for (int i = 0; i < recipes.Length; i++)
            {
                adjList.TryAdd(recipes[i], new List<string>());
                for (int j = 0; j < ingredients[i].Count; j++)
                {
                    // Build adjacency list linking recipes to their ingredients
                    // This is because a recipe can also be an ingredient.
                    // Need to do toplogical sorting to remove circular dependencies
                    // Treat everything as an ingredient with possible edges.
                    adjList[recipes[i]].Add(ingredients[i][j]);
                }
            }

            Stack<string> stack = new Stack<string>();
            foreach (string recipe in recipes)
            {
                dfs(stack, recipe);
            }
            return stack.ToList();
        }

        public bool dfs(Stack<string> stack, string ingredient)
        {
            if (valid.ContainsKey(ingredient))
            {
                return valid[ingredient];
            }
            valid.Add(ingredient, false); // false = GRAY
            if (!suppliesHash.Contains(ingredient) && !recipesHash.Contains(ingredient))
            {
                return false;
            }
            if (adjList.ContainsKey(ingredient))
            {
                foreach (string adj in adjList[ingredient])
                {
                    if (!dfs(stack, adj))
                    {
                        return false; // bubble up a cycle failure
                    }
                }
            }
            if (recipesHash.Contains(ingredient))
            {
                stack.Push(ingredient);
            }
            valid[ingredient] = true; // true = BLACK
            return true;
        }
    }
}