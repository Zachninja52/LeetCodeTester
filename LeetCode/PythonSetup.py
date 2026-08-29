import inspect
import LeetCodeSolutions

# Get all functions defined directly within the module
def GetPythonFunctions() -> str:
    functionsList = [
        name for name, obj in inspect.getmembers(LeetCodeSolutions)
        if inspect.isfunction(obj) and obj.__module__ == LeetCodeSolutions.__name__]
    finalList = ", ".join(functionsList)
    
    return finalList

def ConvertResultToStringOutput(result):
    resultType = type(result)
    if isinstance(result,LeetCodeSolutions.ListNode):
        final = []
        while result is not None:
            final.append(str(result.val))
            result = result.next

        finalAsString = ", ".join(final)
        return "(ListNode) Output: [" + finalAsString + "]"
    elif isinstance(result, (list, tuple)):
        finalAsString = ", ".join(map(str, result))
        return "(int[]) Output: [" + finalAsString + "]"
    else:
        finalAsString = ", ".join(result)
        return "(string[]) Output: [" + finalAsString + "]"


def RunPythonFunction(name: str) -> str:
    function = getattr(LeetCodeSolutions, name)
    arguments = GetFunctionArguments(name)
    # Pass 2 and 3 directly into the function variable
    return ConvertResultToStringOutput(function(*arguments))


def GetFunctionArguments(name):
    match name:
        case "pyTwoSum":
            return [[1,2,7],9]
        case "pyAddTwoNumbers":
            l11 =  LeetCodeSolutions.ListNode()
            l12 =  LeetCodeSolutions.ListNode()
            l13 =  LeetCodeSolutions.ListNode()
            l21 =  LeetCodeSolutions.ListNode()
            l22 =  LeetCodeSolutions.ListNode()
            l23 =  LeetCodeSolutions.ListNode()

            l11.next = l12;
            l12.next = l13;

            l11.val = 2;
            l12.val = 4;
            l13.val = 3;

            l21.val = 5;
            l22.val = 6;
            l23.val = 4;

            l21.next = l22;
            l22.next = l23;
            return [l11,l21]



