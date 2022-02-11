using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace RogueLibsCore
{
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static class TranspilerHelper
	{
        public static IEnumerable<CodeInstruction> RemoveRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool> begin,
            Func<CodeInstruction, bool> end)
            => RemoveRegion(code, new Func<CodeInstruction, bool>[] { begin }, new Func<CodeInstruction, bool>[] { end });
        public static IEnumerable<CodeInstruction> RemoveRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] region)
            => RemoveRegion(code, region, new Func<CodeInstruction, bool>[0]);

        public static IEnumerable<CodeInstruction> RemoveRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin,
            Func<CodeInstruction, bool>[] end)
        {
            if (code is null) throw new ArgumentNullException(nameof(code));
            if (begin is null) throw new ArgumentNullException(nameof(begin));
            if (end is null) throw new ArgumentNullException(nameof(end));
            if (begin.Length is 0) throw new ArgumentException($"{nameof(begin)} cannot be empty.", nameof(begin));
            if (Array.Exists(begin, static b => b is null)) throw new ArgumentException($"Delegates in {nameof(begin)} cannot be null.", nameof(begin));
            if (Array.Exists(end, static b => b is null)) throw new ArgumentException($"Delegates in {nameof(end)} cannot be null.", nameof(end));

            return RemoveRegion2();
            IEnumerable<CodeInstruction> RemoveRegion2()
            {
                SearchState state = SearchState.Searching;
                int current = 0;
                CodeInstruction[] cache = new CodeInstruction[begin.Length];
                foreach (CodeInstruction instr in code)
                {
                    if (state == SearchState.Passed)
                        yield return instr;
                    else if (state == SearchState.Searching)
                    {
                        if (begin[current](instr))
                        {
                            cache[current] = instr;
                            if (++current == begin.Length)
                            {
                                state = end.Length > 0 ? SearchState.Found : SearchState.Passed;
                                current = 0;
                            }
                        }
                        else
                        {
                            if (current > 0)
                            {
                                for (int i = 0; i < current; i++)
                                    yield return cache[i];
                                current = 0;
                            }
                            yield return instr;
                        }
                    }
                    else // if (state == SearchState.Found)
                    {
                        if (end[current](instr))
                        {
                            if (++current == end.Length)
                                state = SearchState.Passed;
                        }
                        else current = 0;
                    }
                }
                if (state == SearchState.Searching) throw new InvalidOperationException("Could not match the beginning of the region to remove.");
                if (state == SearchState.Found) throw new InvalidOperationException("Could not match the end of the region to remove.");
            }
        }



        public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool> after,
            IEnumerable<CodeInstruction> region)
            => AddRegionAfter(code, new Func<CodeInstruction, bool>[] { after }, _ => region);
        public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] after,
            IEnumerable<CodeInstruction> region)
            => AddRegionAfter(code, after, _ => region);
        public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] after,
            IEnumerable<Func<CodeInstruction[], CodeInstruction>> region)
            => AddRegionAfter(code, after, m => region.Select(a => a(m)));

        public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] after,
            Func<CodeInstruction[], IEnumerable<CodeInstruction>> region)
        {
            if (code is null) throw new ArgumentNullException(nameof(code));
            if (after is null) throw new ArgumentNullException(nameof(after));
            if (region is null) throw new ArgumentNullException(nameof(region));
            if (after.Length is 0) throw new ArgumentException($"{nameof(after)} cannot be empty.", nameof(after));
            if (Array.Exists(after, static a => a is null)) throw new ArgumentException($"Delegates in {nameof(after)} cannot be null.", nameof(after));

            return AddRegionAfter2();
            IEnumerable<CodeInstruction> AddRegionAfter2()
            {
                SearchState state = SearchState.Searching;
                int current = 0;
                CodeInstruction[] matches = new CodeInstruction[after.Length];
                foreach (CodeInstruction instr in code)
                {
                    if (state == SearchState.Passed)
                        yield return instr;
                    else
                    {
                        yield return instr;
                        if (after[current](instr))
                        {
                            matches[current] = instr;
                            if (++current == after.Length)
                            {
                                state = SearchState.Passed;
                                CodeInstruction[] arr = new CodeInstruction[matches.Length];
                                matches.CopyTo(arr, 0);
                                IEnumerable<CodeInstruction> added = region(arr);
                                if (added is null) throw new ArgumentException($"{nameof(region)} cannot return null.");
                                foreach (CodeInstruction instr2 in added)
                                {
                                    if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(region)} cannot contain null.", nameof(region));
                                    yield return new CodeInstruction(instr2);
                                }
                            }
                        }
                        else current = 0;
                    }
                }
                if (state == SearchState.Searching) throw new InvalidOperationException("Could not match the after region.");
            }
        }



        public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool> before,
            IEnumerable<CodeInstruction> region)
            => AddRegionBefore(code, new Func<CodeInstruction, bool>[] { before }, _ => region);
        public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] before,
            IEnumerable<CodeInstruction> region)
            => AddRegionBefore(code, before, _ => region);
        public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] before,
            IEnumerable<Func<CodeInstruction[], CodeInstruction>> region)
            => AddRegionBefore(code, before, m => region.Select(a => a(m)));

        public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] before,
            Func<CodeInstruction[], IEnumerable<CodeInstruction>> region)
        {
            if (code is null) throw new ArgumentNullException(nameof(code));
            if (before is null) throw new ArgumentNullException(nameof(before));
            if (region is null) throw new ArgumentNullException(nameof(region));
            if (before.Length is 0) throw new ArgumentException($"{nameof(before)} cannot be empty.", nameof(before));
            if (Array.Exists(before, static b => b is null)) throw new ArgumentException($"Delegates in {nameof(before)} cannot be null.", nameof(before));

            return AddRegionBefore2();
            IEnumerable<CodeInstruction> AddRegionBefore2()
            {
                SearchState state = SearchState.Searching;
                int current = 0;
                CodeInstruction[] matches = new CodeInstruction[before.Length];
                foreach (CodeInstruction instr in code)
                {
                    if (state == SearchState.Passed)
                        yield return instr;
                    else
                    {
                        if (before[current](instr))
                        {
                            matches[current] = instr;
                            if (++current == before.Length)
                            {
                                state = SearchState.Passed;
                                CodeInstruction[] arr = new CodeInstruction[matches.Length];
                                matches.CopyTo(arr, 0);
                                IEnumerable<CodeInstruction> added = region(arr);
                                if (added is null) throw new ArgumentException($"{nameof(region)} cannot return null.");
                                foreach (CodeInstruction instr2 in added)
                                {
                                    if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(region)} cannot contain null.", nameof(region));
                                    yield return new CodeInstruction(instr2);
                                }
                                for (int i = 0; i < current; i++)
                                    yield return matches[i];
                            }
                        }
                        else
                        {
                            if (current > 0)
                            {
                                for (int i = 0; i < current; i++)
                                    yield return matches[i];
                                current = 0;
                            }
                            yield return instr;
                        }
                    }
                }
            }
        }



        public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin,
            Func<CodeInstruction, bool>[] end, IEnumerable<CodeInstruction> replacer)
            => ReplaceRegion(code, begin, end, (_, _) => replacer);
        public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin,
            Func<CodeInstruction, bool>[] end, IEnumerable<Func<CodeInstruction[], CodeInstruction[], CodeInstruction>> replacer)
            => ReplaceRegion(code, begin, end, (a, b) => replacer.Select(r => r(a, b)));

        public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] region, IEnumerable<CodeInstruction> replacer)
            => ReplaceRegion(code, region, new Func<CodeInstruction, bool>[0], (_, _) => replacer);
        public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] region, IEnumerable<Func<CodeInstruction[], CodeInstruction>> replacer)
            => ReplaceRegion(code, region, new Func<CodeInstruction, bool>[0], (replaced, _) => replacer.Select(r => r(replaced)));

        public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin, Func<CodeInstruction, bool>[] end, Func<CodeInstruction[], CodeInstruction[], IEnumerable<CodeInstruction>> replacer)
        {
            if (code is null) throw new ArgumentNullException(nameof(code));
            if (begin is null) throw new ArgumentNullException(nameof(begin));
            if (end is null) throw new ArgumentNullException(nameof(end));
            if (replacer is null) throw new ArgumentNullException(nameof(replacer));
            if (begin.Length is 0) throw new ArgumentException($"{nameof(begin)} cannot be empty.", nameof(begin));
            if (Array.Exists(begin, static b => b is null)) throw new ArgumentException($"Delegates in {nameof(begin)} cannot be null.", nameof(begin));
            if (Array.Exists(end, static e => e is null)) throw new ArgumentException($"Delegates in {nameof(end)} cannot be null.", nameof(end));

            return ReplaceRegion2();
            IEnumerable<CodeInstruction> ReplaceRegion2()
            {
                SearchState state = SearchState.Searching;
                int current = 0;
                CodeInstruction[] beginCache = new CodeInstruction[begin.Length];
                CodeInstruction[] endCache = new CodeInstruction[end.Length];
                foreach (CodeInstruction instr in code)
                {
                    if (state == SearchState.Passed)
                        yield return instr;
                    else if (state == SearchState.Searching)
                    {
                        if (begin[current](instr))
                        {
                            beginCache[current] = instr;
                            if (++current == begin.Length)
                            {
                                state = end.Length > 0 ? SearchState.Found : SearchState.Passed;
                                if (state == SearchState.Passed)
                                {
                                    IEnumerable<CodeInstruction> replaced = replacer(beginCache, endCache);
                                    if (replaced is null) throw new ArgumentException($"{nameof(replacer)} cannot return null.");
                                    foreach (CodeInstruction instr2 in replaced)
                                    {
                                        if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(replacer)} cannot contain null.", nameof(replacer));
                                        yield return new CodeInstruction(instr2);
                                    }
                                }
                                current = 0;
                            }
                        }
                        else
                        {
                            if (current > 0)
                            {
                                for (int i = 0; i < current; i++)
                                    yield return beginCache[i];
                                current = 0;
                            }
                            yield return instr;
                        }
                    }
                    else // if (state == SearchState.Found)
                    {
                        if (end[current](instr))
                        {
                            endCache[current] = instr;
                            if (++current == end.Length)
                            {
                                state = SearchState.Passed;
                                IEnumerable<CodeInstruction> replaced = replacer(beginCache, endCache);
                                if (replaced is null) throw new ArgumentException($"{nameof(replacer)} cannot return null.");
                                foreach (CodeInstruction instr2 in replaced)
                                {
                                    if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(replacer)} cannot contain null.", nameof(replacer));
                                    yield return new CodeInstruction(instr2);
                                }
                            }
                        }
                        else current = 0;
                    }
                }
            }
        }



        private enum SearchState
        {
            Searching = 0,
            Found     = 1,
            Passed    = 2,
        }

        public static CodeInstruction WithLabels(this CodeInstruction instruction, CodeInstruction otherInstruction)
        {
            CodeInstruction instr = new CodeInstruction(instruction);
            instr.labels.AddRange(otherInstruction.labels);
            return instr;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore IDE0079 // Remove unnecessary suppression
}
