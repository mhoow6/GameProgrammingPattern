using System;
using System.Collections.Generic;
using System.Text;

/**********************************
 * 싱글톤 패턴
 * 단 하나의 객체만을 생성하게 강제하는 디자인 패턴
 **********************************/

namespace Lesson_2
{
    class singleton
    {
        private static singleton one;
        private singleton()
        {
        }

        public static singleton getInstance()
        {
            // 메소드 호출 시 인스턴스가 없는 경우(null)
            // singleton 객체가 생성
            if (one == null)
            {
                one = new singleton();
            }

            // 싱글톤 객체 생성 후 더 이상 null이 아닌경우
            // 항상 최초 생성된 싱글톤 객체를 리턴
            return one;
        }

        public class SingletonTest
        {
            public static void Main(String[] args)
            {
                singleton singleton1 = singleton.getInstance();
                singleton singleton2 = singleton.getInstance();
                Console.WriteLine(singleton1 == singleton2);
            }
        }
    }
}
