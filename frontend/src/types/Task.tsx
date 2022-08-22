export interface TaskItem {
  id: string
  completed: boolean
  description: string
}
export interface TaskCategories {
  pending: TaskItem[]
  completed: TaskItem[]
}

