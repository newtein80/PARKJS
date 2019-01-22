using System;
using System.Collections.Generic;
using System.Text;

namespace PARKJS.Domain.Core.Models
{
    // Entity에 대해서 추상클래스를 만들어 사용한다. 기본적인 메소드들을 override 하여 코딩의 양을 줄인다.
    /// <summary>
    /// Entity에 대해서 추상클래스를 만들어 사용한다. 기본적인 메소드들을 override 하여 사용
    /// </summary>
    public abstract class Entity
    {
        // protected 선언하여 자신 또는 자식클래스만 set 을 할 수 있다.
        public Guid Id { get; protected set; }

        // Object 의 Equals 를 override를 한다. 아프로 Entity를 상속받은 자식 클래스의 Equal은 다음 함수를 따른다.
        // ReferenceEquals 과 Equals(id) 모두 검사
        /// <summary>
        /// ReferenceEquals 과 Equals(id) 모두 검사
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            // 박종수 : ReferenceEquals는 참조된 개체가 같은지를 판단
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            // http://ehpub.co.kr/tag/referenceequals/
            // 개체의 멤버 Equals는 가상 메서드이기 때문에 목적에 따라 값이 같은지를 판단하게 재정의가 가능
            // object.ReferenceEquals 메서드와 ceq(기본 == 연산자)의 기본 동작은 "참조 주소 값 같음. - reference equality (also known as identity)"에 해당합니다.
            // 즉, 관리 힙에 할당된 객체의 참조 주소 값을 비교해 '같음 여부'를 판단하는 것입니다.
            // 이 때문에, object.ReferenceEquals 메서드와 ceq(기본 == 연산자)는 '값 형식'의 인스턴스에 사용해서는 안됩니다.
            // ==, Equals, ReferenceEquals 는 각각 상황에 맞게 사용
            return Id.Equals(compareTo.Id);
        }

        // operator 키워드를 사용하여 기본 제공 연산자를 오버로드하거나 클래스 또는 구조체 선언에서 사용자 정의 변환을 제공할 수 있습니다.
        // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/operator
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        // GetHashCode는 가상 메서드이기 때문에 목적에 맞게 재정의 가능
        // 실제 반환되는 값이 어떻게 발생하는지 규칙성이 없고 유일성을 보장하지 않습니다.
        // 확률적으로 같은 값을 반환할 경우가 적다는 이유로 고유한 키로 사용하지 마십시오.
        // GetType 메서드는 형식에 대한 상세정보를 갖는 Type 개체를 반환
        /// <summary>
        /// 해시 테이블과 같은 자료구조를 이용하여 개체를 관리할 때 적합한 키를 반환하는 메서드
        /// </summary>
        /// <returns>고유 Key (규칙성이 없고 유일성을 보장하지 않음)</returns>
        public override int GetHashCode()
        {
            // 해시 테이블과 같은 자료구조를 이용하여 개체를 관리할 때 적합한 키를 반환하는 메서드입니다.
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        /// <summary>
        /// ToString 을 override 하여 GetType().Name + " [Id=" + Id + "]" 반환
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
