using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Generic<T>
{
    public string Expression { get; set; }
    public T Result { get; set; }

    public override string ToString()
    {
        return $"{Expression} = {Result}";
    }
}
