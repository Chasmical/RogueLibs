# Custom Name Providers

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import useBaseUrl from '@docusaurus/useBaseUrl';

If you have some kind of complicated naming strategy, then you might want to use `INameProvider`. This way you can control what strings are returned by `NameDB.GetName` in a more generic way. Just create a class implementing `INameProvider` and add it to `RogueFramework`.

```csharp title="MyNameProvider.cs"
public class MyNameProvider : INameProvider
{
    public void GetName(string name, string type, ref string result)
    {
        if (name.StartsWith("fake_"))
        {
            string sub = name.Substring("fake_".Length);
            result = LanguageService.NameDB.GetName(sub, type);
        }
    }
}
```

:::note
If the original `NameDB.GetName` returned an error string (with `E_` prefix), `result` is set to `null`.
:::

```csharp
RogueFramework.NameProviders.Add(new MyNameProvider());
```

Here's a more practical and useful example, that is already implemented in RogueLibs:

```csharp
public class DialogueNameProvider : INameProvider
{
	public void GetName(string name, string type, ref string result)
	{
		if (result is null && type == "Dialogue" && name.StartsWith("NA_"))
		{
			string sub = name.Substring("NA_".Length);
			string newResult = LanguageService.NameDB.GetName(sub, type);
			if (!newResult.StartsWith("E_")) result = newResult;
		}
	}
}
```

Normally, the game looks for dialogue names of the following format: `<AgentName>_<DialogueName>`. If such a name doesn't exist, then `NA_<DialogueName>` (NA - No Agent) is used instead. This name provider will also look for a name with just the dialogue name. This allows the developers to write dialogue names without that annoying `NA_` prefix.