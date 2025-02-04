#if MORPEH_BURST
using System;
using System.Reflection;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh.Native;
using Unity.Jobs;

namespace Scellecs.Morpeh
{
    public static class QueryBuilderJobsExtensions
    {
        // ------------------------------------------------- //
        // 1 parameter
        // ------------------------------------------------- //

        public delegate void E<T1>(NativeFilter entities, NativeStash<T1> component1)
            where T1 : unmanaged, IComponent;

        public static QueryBuilder ForEachNative<T1>(this QueryBuilder queryBuilder, E<T1> callback)
            where T1 : unmanaged, IComponent
        {
            var filter = queryBuilder.Build();
            if (!filter.hasFilter)
                throw new NotImplementedException($"You're not allowed to use [{nameof(ForEachNative)}] on an empty filter in [{queryBuilder.System.GetType().Name}]");
            
            if (!queryBuilder.skipValidationEnabled)
                QueryHelper.ValidateRequest(queryBuilder, filter, QueryHelper.GetRequestedTypeInfo<T1>());

            var stashT1 = queryBuilder.World.GetStash<T1>();
            queryBuilder.System.AddExecutor(() =>
            {
                var nativeFilter = filter.AsNative();
                callback.Invoke(nativeFilter, stashT1.AsNative());
            });
            return queryBuilder;
        }

        // ------------------------------------------------- //
        // 2 parameters
        // ------------------------------------------------- //

        public delegate void E<T1, T2>(NativeFilter entities, NativeStash<T1> component1, NativeStash<T2> component2)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent;

        public static QueryBuilder ForEachNative<T1, T2>(this QueryBuilder queryBuilder, E<T1, T2> callback)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
        {
            var filter = queryBuilder.Build();
            if (!filter.hasFilter)
                throw new NotImplementedException($"You're not allowed to use [{nameof(ForEachNative)}] on an empty filter in [{queryBuilder.System.GetType().Name}]");

            if (!queryBuilder.skipValidationEnabled)
                QueryHelper.ValidateRequest(queryBuilder, filter, QueryHelper.GetRequestedTypeInfo<T1>(), QueryHelper.GetRequestedTypeInfo<T2>());

            var stashT1 = queryBuilder.World.GetStash<T1>();
            var stashT2 = queryBuilder.World.GetStash<T2>();
            queryBuilder.System.AddExecutor(() =>
            {
                var nativeFilter = filter.AsNative();
                callback.Invoke(nativeFilter, stashT1.AsNative(), stashT2.AsNative());
            });
            return queryBuilder;
        }

        // ------------------------------------------------- //
        // 3 parameters
        // ------------------------------------------------- //

        public delegate void E<T1, T2, T3>(NativeFilter entities, NativeStash<T1> component1, NativeStash<T2> component2, NativeStash<T3> component3)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent;

        public static QueryBuilder ForEachNative<T1, T2, T3>(this QueryBuilder queryBuilder, E<T1, T2, T3> callback)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
        {
            var filter = queryBuilder.Build();
            if (!filter.hasFilter)
                throw new NotImplementedException($"You're not allowed to use [{nameof(ForEachNative)}] on an empty filter in [{queryBuilder.System.GetType().Name}]");

            if (!queryBuilder.skipValidationEnabled)
                QueryHelper.ValidateRequest(queryBuilder, filter, QueryHelper.GetRequestedTypeInfo<T1>(), QueryHelper.GetRequestedTypeInfo<T2>(),
                    QueryHelper.GetRequestedTypeInfo<T3>());

            var stashT1 = queryBuilder.World.GetStash<T1>();
            var stashT2 = queryBuilder.World.GetStash<T2>();
            var stashT3 = queryBuilder.World.GetStash<T3>();
            queryBuilder.System.AddExecutor(() =>
            {
                var nativeFilter = filter.AsNative();
                callback.Invoke(nativeFilter, stashT1.AsNative(), stashT2.AsNative(), stashT3.AsNative());
            });
            return queryBuilder;
        }

        // ------------------------------------------------- //
        // 4 parameters
        // ------------------------------------------------- //

        public delegate void E<T1, T2, T3, T4>(NativeFilter entities, NativeStash<T1> component1, NativeStash<T2> component2, NativeStash<T3> component3,
            NativeStash<T4> component4)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
            where T4 : unmanaged, IComponent;

        public static QueryBuilder ForEachNative<T1, T2, T3, T4>(this QueryBuilder queryBuilder, E<T1, T2, T3, T4> callback)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
            where T4 : unmanaged, IComponent
        {
            var filter = queryBuilder.Build();
            if (!filter.hasFilter)
                throw new NotImplementedException($"You're not allowed to use [{nameof(ForEachNative)}] on an empty filter in [{queryBuilder.System.GetType().Name}]");

            if (!queryBuilder.skipValidationEnabled)
                QueryHelper.ValidateRequest(queryBuilder, filter, QueryHelper.GetRequestedTypeInfo<T1>(), QueryHelper.GetRequestedTypeInfo<T2>(),
                    QueryHelper.GetRequestedTypeInfo<T3>(), QueryHelper.GetRequestedTypeInfo<T4>());

            var stashT1 = queryBuilder.World.GetStash<T1>();
            var stashT2 = queryBuilder.World.GetStash<T2>();
            var stashT3 = queryBuilder.World.GetStash<T3>();
            var stashT4 = queryBuilder.World.GetStash<T4>();
            queryBuilder.System.AddExecutor(() =>
            {
                var nativeFilter = filter.AsNative();
                callback.Invoke(nativeFilter, stashT1.AsNative(), stashT2.AsNative(), stashT3.AsNative(), stashT4.AsNative());
            });
            return queryBuilder;
        }

        // ------------------------------------------------- //
        // 5 parameters
        // ------------------------------------------------- //

        public delegate void E<T1, T2, T3, T4, T5>(NativeFilter entities, NativeStash<T1> component1, NativeStash<T2> component2, NativeStash<T3> component3,
            NativeStash<T4> component4,
            NativeStash<T5> component5)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
            where T4 : unmanaged, IComponent
            where T5 : unmanaged, IComponent;

        public static QueryBuilder ForEachNative<T1, T2, T3, T4, T5>(this QueryBuilder queryBuilder, E<T1, T2, T3, T4, T5> callback)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
            where T4 : unmanaged, IComponent
            where T5 : unmanaged, IComponent
        {
            var filter = queryBuilder.Build();
            if (!filter.hasFilter)
                throw new NotImplementedException($"You're not allowed to use [{nameof(ForEachNative)}] on an empty filter in [{queryBuilder.System.GetType().Name}]");

            if (!queryBuilder.skipValidationEnabled)
                QueryHelper.ValidateRequest(queryBuilder, filter, QueryHelper.GetRequestedTypeInfo<T1>(), QueryHelper.GetRequestedTypeInfo<T2>(),
                    QueryHelper.GetRequestedTypeInfo<T3>(), QueryHelper.GetRequestedTypeInfo<T4>(), QueryHelper.GetRequestedTypeInfo<T5>());

            var stashT1 = queryBuilder.World.GetStash<T1>();
            var stashT2 = queryBuilder.World.GetStash<T2>();
            var stashT3 = queryBuilder.World.GetStash<T3>();
            var stashT4 = queryBuilder.World.GetStash<T4>();
            var stashT5 = queryBuilder.World.GetStash<T5>();
            queryBuilder.System.AddExecutor(() =>
            {
                var nativeFilter = filter.AsNative();
                callback.Invoke(nativeFilter, stashT1.AsNative(), stashT2.AsNative(), stashT3.AsNative(), stashT4.AsNative(), stashT5.AsNative());
            });
            return queryBuilder;
        }

        // ------------------------------------------------- //
        // 6 parameters
        // ------------------------------------------------- //

        public delegate void E<T1, T2, T3, T4, T5, T6>(NativeFilter entities, NativeStash<T1> component1, NativeStash<T2> component2, NativeStash<T3> component3,
            NativeStash<T4> component4,
            NativeStash<T5> component5, NativeStash<T6> component6)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
            where T4 : unmanaged, IComponent
            where T5 : unmanaged, IComponent
            where T6 : unmanaged, IComponent;

        public static QueryBuilder ForEachNative<T1, T2, T3, T4, T5, T6>(this QueryBuilder queryBuilder, E<T1, T2, T3, T4, T5, T6> callback)
            where T1 : unmanaged, IComponent
            where T2 : unmanaged, IComponent
            where T3 : unmanaged, IComponent
            where T4 : unmanaged, IComponent
            where T5 : unmanaged, IComponent
            where T6 : unmanaged, IComponent
        {
            var filter = queryBuilder.Build();
            if (!filter.hasFilter)
                throw new NotImplementedException($"You're not allowed to use [{nameof(ForEachNative)}] on an empty filter in [{queryBuilder.System.GetType().Name}]");

            if (!queryBuilder.skipValidationEnabled)
                QueryHelper.ValidateRequest(queryBuilder, filter, QueryHelper.GetRequestedTypeInfo<T1>(), QueryHelper.GetRequestedTypeInfo<T2>(),
                    QueryHelper.GetRequestedTypeInfo<T3>(), QueryHelper.GetRequestedTypeInfo<T4>(), QueryHelper.GetRequestedTypeInfo<T5>(),
                    QueryHelper.GetRequestedTypeInfo<T6>());

            var stashT1 = queryBuilder.World.GetStash<T1>();
            var stashT2 = queryBuilder.World.GetStash<T2>();
            var stashT3 = queryBuilder.World.GetStash<T3>();
            var stashT4 = queryBuilder.World.GetStash<T4>();
            var stashT5 = queryBuilder.World.GetStash<T5>();
            var stashT6 = queryBuilder.World.GetStash<T6>();
            queryBuilder.System.AddExecutor(() =>
            {
                var nativeFilter = filter.AsNative();
                callback.Invoke(nativeFilter, stashT1.AsNative(), stashT2.AsNative(), stashT3.AsNative(), stashT4.AsNative(),
                    stashT5.AsNative(), stashT6.AsNative());
            });
            return queryBuilder;
        }
    }
}
#endif