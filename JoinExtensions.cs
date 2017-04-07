using System;
using System.Collections.Generic;
using System.Linq;

namespace Joins
{
    public static class JoinExtensions
    {

        public static IEnumerable<TResult> LeftJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                         IEnumerable<TInner> inner, 
                                                                                         Func<TSource, TKey> pk, 
                                                                                         Func<TInner, TKey> fk, 
                                                                                         Func<TSource, TInner, TResult> result)
        {
            return source.GroupJoin(inner, pk, fk, (s, joinData) => new {s, joinData}).SelectMany(@t => @t.joinData.DefaultIfEmpty(), (@t, left) => result(@t.s, left));
        }


        public static IEnumerable<TResult> RightJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                         IEnumerable<TInner> inner,
                                                                                         Func<TSource, TKey> pk,
                                                                                         Func<TInner, TKey> fk,
                                                                                         Func<TSource, TInner, TResult> result)
        {
            return inner.GroupJoin(source, fk, pk, (i, joinData) => new {i, joinData}).SelectMany(@t => @t.joinData.DefaultIfEmpty(), (@t, right) => result(right, @t.i));

        }


        public static IEnumerable<TResult> FullOuterJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
																							IEnumerable<TInner> inner,
																							Func<TSource, TKey> pk,
																							Func<TInner, TKey> fk,
																							Func<TSource, TInner, TResult> result)
        {
            var left = source.LeftJoin(inner, pk, fk, result).ToList();
            var right = source.RightJoin(inner, pk, fk, result).ToList();
            return left.Union(right);
        }


        public static IEnumerable<TResult> LeftExcludingJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                         IEnumerable<TInner> inner,
                                                                                         Func<TSource, TKey> pk,
                                                                                         Func<TInner, TKey> fk,
                                                                                         Func<TSource, TInner, TResult> result)
        {
            return source.GroupJoin(inner, pk, fk, (s, joinData) => new {s, joinData})
                    .SelectMany(@t => @t.joinData.DefaultIfEmpty(), (@t, left) => new {@t, left})
                    .Where(@t => @t.left == null)
                    .Select(@t => result(@t.@t.s, @t.left));
        }

        public static IEnumerable<TResult> RightExcludingJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                 IEnumerable<TInner> inner,
                                                                                 Func<TSource, TKey> pk,
                                                                                 Func<TInner, TKey> fk,
                                                                                 Func<TSource, TInner, TResult> result)
        {
            return inner.GroupJoin(source, fk, pk, (i, joinData) => new {i, joinData})
                    .SelectMany(@t => @t.joinData.DefaultIfEmpty(), (@t, right) => new {@t, right})
                    .Where(@t => @t.right == null)
                    .Select(@t => result(@t.right, @t.@t.i));
        }


        public static IEnumerable<TResult> FulltExcludingJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                            IEnumerable<TInner> inner,
                                                                            Func<TSource, TKey> pk,
                                                                            Func<TInner, TKey> fk,
                                                                            Func<TSource, TInner, TResult> result)
        {
            var left = source.LeftExcludingJoin(inner, pk, fk, result).ToList();
            var right = source.RightExcludingJoin(inner, pk, fk, result).ToList();
            return left.Union(right);
        }
    }
}
