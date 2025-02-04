using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Native;

namespace Scellecs.Morpeh
{
    public readonly struct CompiledQuery
    {
        public readonly Filter filter;
        public readonly bool hasFilter;
        public World World => filter.world;

        public struct WorldEntitiesEnumerator : IEnumerator<Entity>
        {
            private readonly EntityData[] m_entities;
            private int m_index;
            private bool m_useEntityEnumerator;
            private Filter.Enumerator m_entityEnumerator;

            public WorldEntitiesEnumerator(EntityData[] worldEntities)
            {
                m_entities = worldEntities;
                m_index = 0;
                m_useEntityEnumerator = false;
                m_entityEnumerator = default;
            }

            public WorldEntitiesEnumerator(Filter.Enumerator entityEnumerator)
            {
                m_entities = default;
                m_index = 0;
                m_useEntityEnumerator = true;
                m_entityEnumerator = entityEnumerator;
            }

            public bool MoveNext()
            {
                if (m_useEntityEnumerator)
                    return m_entityEnumerator.MoveNext();

                m_index++;
                return m_index < m_entities.Length - 1;
            }

            public void Reset()
            {
                if (m_useEntityEnumerator)
                {
                    m_entityEnumerator.entityIndex = 0;
                    return;
                }
                m_index = 0;
            }

            public Entity Current => m_useEntityEnumerator ? m_entityEnumerator.Current : m_entities[m_index].currentArchetype.entities.data[m_entities[m_index].indexInCurrentArchetype];

            object IEnumerator.Current => m_useEntityEnumerator ? m_entityEnumerator.Current : Current;

            public void Dispose()
            {
                if (m_useEntityEnumerator)
                    m_entityEnumerator.Dispose();
            }
        }

        public CompiledQuery(Filter filter)
        {
            this.filter = filter;
            hasFilter = filter.excludedTypeIds.Length > 0 || filter.includedTypeIds.Length > 0;
        }

        public bool IsEmpty()
        {
            if (!hasFilter)
                return filter.world.entities.Length == 0;

            return filter.IsEmpty();
        }

        public WorldEntitiesEnumerator GetEnumerator()
        {
            if (!hasFilter)
                return new WorldEntitiesEnumerator(filter.world.entities);

            return new WorldEntitiesEnumerator(filter.GetEnumerator());
        }

        public NativeFilter AsNative()
        {
            return filter.AsNative();
        }
    }
}