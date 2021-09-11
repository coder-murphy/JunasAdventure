using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.FDGameSDK.Extensions;

namespace Assets.FDGameSDK.FPSupport
{
    /// <summary>
    /// 函数式编程扩展
    /// </summary>
    public static class FPExtensions
    {
        /// <summary>
        /// 运行switch语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="switchs"></param>
        public static void Switch<T>(this IEnumerable<IFPSwitchLine<T>> switchs)
        {
            switchs.ForAll(x => {
                if (x != null && x.Src != null && x.MyAction != null && x.Expression != null)
                {
                    if (x.Expression(x.Src))
                    {
                        x.MyAction(x.Src);
                        return;
                    }
                }
            });
        }

        /// <summary>
        /// 多重返回
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="source"></param>
        /// <param name="func0"></param>
        /// <param name="func1"></param>
        /// <returns></returns>
        public static Tuple<T0, T1> MultiReturn<TSource, T0, T1>(this TSource source, Func<TSource, T0> func0, Func<TSource, T1> func1)
        {
            return new Tuple<T0, T1>(func0(source), func1(source));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func0"></param>
        /// <param name="func1"></param>
        /// <param name="func2"></param>
        /// <param name="func3"></param>
        /// <param name="func4"></param>
        /// <returns></returns>
        public static Func<T0, TResult> GetComposeFunc<T0, T1, T2, T3, T4, TResult>(
            Func<T0, T1> func0,
            Func<T1, T2> func1,
            Func<T2, T3> func2,
            Func<T3, T4> func3,
            Func<T4, TResult> func4)
        {
            return x => func4(func3(func2(func1(func0(x)))));
        }

        /// <summary>
        /// 方法逆转
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func0"></param>
        /// <param name="func1"></param>
        /// <returns></returns>
        public static Func<TResult, T0> GetReverseFunc<T0, T1, TResult>(this Func<T0, T1> func0, Func<T1, TResult> func1)
            where T1 : T0
            where TResult : T1
        {
            //normal func1(func0(source));
            //Func<T0, TResult> func = x => func1(func0(x));
            //Func<TResult, T0> funcR = x => func0(func1(x));
            return x => func0(func1(x));
        }
    }
}
