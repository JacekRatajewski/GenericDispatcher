# GenericDispatcher
Generic Dispatcher - Module managing saving and loading data from/to json file.

**Adopt to file example:**

    var list = new List<object>();
    GDispatcher<List<object>>.Adopt("path/to/file", list);

**Dispatch from file example:**

    var list = await GDispatcher<List<object>>.Dispatch("path/to/file");
    var list2 = await GDispatcher<List<object>>.Dispatch("path/to/file", Encoding.UTF8);
