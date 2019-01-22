using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Core.Models
{
    // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    // 단순 값을 갖는 객체 (ID 또는 KEY 가 존재하지 않는 정보용의 데이터 객체??????)
    /// <summary>
    /// 단순 값을 갖는 객체 (ID 또는 KEY 가 존재하지 않는 정보용의 데이터 객체??????)
    /// </summary>
    /// <typeparam name="T">Generic Object</typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            return !ReferenceEquals(valueObject, null) && EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
