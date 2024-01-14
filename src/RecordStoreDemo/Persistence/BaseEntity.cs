﻿namespace RecordStoreDemo.Persistence;
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}