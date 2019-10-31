//GameUI命令空间
/**
 */
namespace GameNumType
{
    /* abstract ANumType: IType, 抽象type类
    所有的类型如,KWNumType,KNumType,AtomNumType,均是此类的派生类
    所有符号操作均产生一个新的ANumType对象
    数值不允许产生负值情况,如果需要负值请使用继承或者组合模式
     */
    abstract class ANumType : IType
    {
        private abstract float num; // 保存数字
        private abstract static string typeName; // 保存类型名称
        private abstract static bool canToTransformUpType; // 类型可上升
        private abstract static bool canToTransformDownType; // 类型可下降
        private abstract static int typeRank; // 类型等级,1为最低等级,因算时上转类型
        public ANumType() { }

        public ANumType(float num)
        {
            if (num < 0)
            {
                throw new MinusException("数值不能为负");
            }
            this.num = num;
        }

        public float Num
        {
            get
            {
                return this.num;
            }
            set
            {
                if (value < 0)
                    throw new MinusException("数值不能是负");
                this.num = value;
            }
        }

        public static string TypeName
        {
            get
            {
                return this.typeName;
            }
        }

        public static bool CanToTransformUpType
        {
            get
            {
                return this.canToTransformUpType;
            }
        }
        public static bool CanToTransformDownType
        {
            get
            {
                return this.canToTransformDownType;
            }
        }

        public static int TypeRank()
        {
            get
            {
                return this.typeRank;
            }
        }

        public ANumType ToTransformUpType()
        {
            if (this.canToTransformUpType)
                this.TransformUpType();
            else
                throw new TransFormUpTypeException("类型不能上升");
        }

        public ANumType ToTransformDownType()
        {
            if (this.canToTransformDownType)
                this.TransformDownType();
            else
                throw new TransFormDownTypeException("类型不能下降");
        }

        public ANumType ToTransformDownAtomNumType()
        {
            ANumType retANumType = this;
            while(retANumType.typeRank > 1)
            {
                retANumType = retANumType.ToTransformDownType();
            }
            return retANumType;
        }
        private abstract ANumType TransformUpType();

        private abstract ANumType TransformDownType();

        public static ANumType operator+(ANumType a, ANumType b)
        {
            ANumType aANumType = a.ToTransformDownAtomNumType();
            ANumType bANumType = b.ToTransformDownAtomNumType();
            aANumType.Num = aANumType.Num + bANumType.Num;
            return aANumType;
        }

        public static ANumType operator-(ANumType a, ANumType b)
        {
            ANumType aANumType = a.ToTransformDownAtomNumType();
            ANumType bANumType = b.ToTransformDownAtomNumType();
            aANumType.num -= bANumType.num;
            if(aANumType.num < 0)
                throw new MinusException("数值运算产生负数");
            return aANumType;
        }

        public static ANumType operator*(ANumType a, float b)
        {
            ANumType aANumType = a.Clone();
            aANumType.num *= b;
            return aANumType;
        }
        public static ANumType operator*(ANumType a, int b)
        {
            ANumType aANumType = a.Clone();
            aANumType.num *= b;
            return aANumType;
        }

        public static ANumType operator/(ANumType a, int b)
        {
            ANumType aANumType = a.Clone();
            aANumType.num /= b;
            return aANumType;
        }
        public static ANumType operator/(ANumType a, float b)
        {
            ANumType aANumType = a.Clone();
            aANumType.num /= b;
            return aANumType;
        }
        public static bool operator>()
        {

        }
        public static bool operator>=()
        {

        }
        public static bool operator<()
        {

        }
        public static bool operator<=()
        {

        }
        public static bool operator==()
        {

        }

        public ANumType Clone()
        {
            switch(this.typeRank)
            {
                case 1:
                    return new AtomNumType(this.num);
                    break;
                case 2:
                    return new KNumType(this.num);
                    break;
                case 3:
                    return new KWNumType(this.num);
                    break;
                default:
                    return null;
                    break;
            }
        }

        public string ToString()
        {
            return this.num + this.typeName;
        }

    }

    class AtomNumType : ANumType
    {
        private override float num = 0;
        private override string typeName = "Atom";
        private override bool canToTransformUpType = True;
        private override bool canToTransformDownType = True;
        private override int typeRank = 1;

        private override ANumType TransfromUpType()
        {
            return new KWNumType(this.num * 1000);
        }

        private override ANumType TransformDownType()
        {
            return null;
        }
    }

    class KNumType : ANumType
    {
        private override float num = 0;
        private override string typeName = "K";
        private override bool canToTransformUpType = True;
        private override bool canToTransformDownType = True;
        private override int typeRank = 2;

        private override ANumType TransfromUpType()
        {
            return new KWNumType(this.num * 10000);
        }

        private override ANumType TransformDownType()
        {
            return new AtomNumType(this.num / 1000f);
        }
    }

    class KNumType : ANumType
    {
        private override float num = 0;
        private override string typeName = "K";
        private override bool canToTransformUpType = True;
        private override bool canToTransformDownType = True;
        private override int typeRank = 3;

        private override ANumType TransfromUpType()
        {
            return null;
        }

        private override ANumType TransformDownType()
        {
            return new AtomNumType(this.num / 10000f);
        }
    }

    //类型不能上升异常
    public class TransfromUpTypeException : Exception
    {
        private string error;
        private Exception innerException;
        public TransfromUpTypeException()
        {

        }
        public TransfromUpTypeException(string msg) : base(msg)
        {
            this.error = msg;
        }
        public TransfromUpTypeException(string msg, Exception innerException) : base(msg)
        {
            this.innerException = innerException;
            this.error = msg;
        }

        public string GetError()
        {
            return error;
        }
    }

    //类型不能下降异常
    public class TransFormDownTypeException : Exception
    {
        private string error;
        private Exception innerException;
        public TransFormDownTypeException()
        {

        }
        public TransFormDownTypeException(string msg) : base(msg)
        {
            this.error = msg;
        }
        public TransFormDownTypeException(string msg, Exception innerException) : base(msg)
        {
            this.innerException = innerException;
            this.error = msg;
        }

        public string GetError()
        {
            return error;
        }
    }

    /* MinusException:Exception, 负数异常
    设置数值如果为负数才可以抛出此异常
     */
    public class MinusException : Exception
    {
        private string error;
        private Exception innerException;

        public MinusException()
        {

        }

        //带一个字符串参数的构造函数，作用：当程序员用Exception类获取异常信息而非 MyException时把自定义异常信息传递过去
        public MinusException(string msg) : base(msg)
        {
            this.error = msg;
        }

        public MinusException(string msg, Exception innerException) : base(msg)
        {
            this.innerException = innerException;
            this.error = msg;
        }

        public string GetError()
        {
            return error;
        }
    }
}