public enum SetDataResult{
	Success, // When data was set.
	ByteSizeChanged // When ByteSize is changed mid set, such as when updating variable length objects.
}