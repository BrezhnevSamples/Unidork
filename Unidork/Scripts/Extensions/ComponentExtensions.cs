using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unidork.Extensions
{
	public static class ComponentExtensions
	{
		#region Get

		/// <summary>
		/// Gets a component on a game object component is attached to without allocating memory.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="component">Component from whose game object to get another component.</param>
		/// <returns>
		/// An instance of <typeparamref name="T"/> or null if component's game object doesn't have a component of specified type attached.
		/// </returns>
		public static T GetComponentNonAlloc<T>(this Component component) where T : Component => component.gameObject.GetComponentNonAlloc<T>();

		/// <summary>
		/// Gets a component on a game object component is attached to without allocating memory.
		/// </summary>
		/// <param name="type">Type of component to get.</param>
		/// <param name="component">Component from whose game object to get another component.</param>
		/// <returns>
		/// An instance of <paramref name="type"/> or null if component's game object doesn't have a component of specified type attached.
		/// </returns>
		public static Component GetComponentNonAlloc(this Component component, Type type) => component.gameObject.GetComponentNonAlloc(type);
		
		/// <summary>
		/// Gets a component of specified type or adds it to a game object component is attached to and returns.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="component">Component whose game object needs to get checked for a component of type <typeparamref name="T"/>.</param>
		/// <returns>
		/// Existing component of type <typeparamref name="T"/> or a new one if it doesn't exist.
		/// </returns>
		public static T GetOrAddComponent<T>(this Component component) where T : Component
		{
			T componentToReturn = component.GetComponentNonAlloc<T>();

			if (componentToReturn == null)
			{
				componentToReturn = component.gameObject.AddComponent<T>();
			}

			return componentToReturn;
		}
		
		/// <summary>
		/// Gets a component of specified type or adds it to a game object and returns.
		/// </summary>
		/// <param name="component">Component whose game object needs to get checked for a component of type <see cref="componentType"/>.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <returns>
		/// Existing component of type <see cref="componentType"/> or a new one if it doesn't exist.
		/// </returns>
		public static Component GetOrAddComponent(this Component component, Type componentType)
		{
			Component componentToReturn = component.GetComponentNonAlloc(componentType);

			if (componentToReturn == null)
			{
				componentToReturn = component.gameObject.AddComponent(componentType);
			}

			return componentToReturn;
		}

		/// <summary>
		/// Gets the first located component of type <typeparamref name="T"/> in the children of the game object
		/// component is attached to using a non-allocating method. 
		/// Optionally ignores the parent transform.
		/// Children of the object are acquired through a breadth-first search.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="component">Component whose hierarchy to search.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// Component of type <typeparamref name="T"/> or null if none of component's game object children have the component.
		/// </returns>
		public static T GetComponentInChildrenNonAlloc<T>(this Component component, bool ignoreCaller = false) where T : Component
		{
			return component.gameObject.GetComponentInChildrenNonAlloc<T>(ignoreCaller);
		}
		
		/// <summary>
		/// Gets the first located component of specified type in children of the game object
		/// component is attached to using a non-allocating method. 
		/// Optionally ignores the parent transform.
		/// Children of the object are acquired through a breadth-first search.
		/// </summary>
		/// <param name="component">Component whose hierarchy to search.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// Component of type <see cref="componentType"/> or null if none of component's game object children have the component.
		/// </returns>
		public static Component GetComponentInChildrenNonAlloc(this Component component, Type componentType, bool ignoreCaller = false)
		{
			return component.gameObject.GetComponentInChildrenNonAlloc(componentType, ignoreCaller);
		}

		/// <summary>
		/// Gets all components of type <typeparamref name="T"/> in children of the game object
		/// component is attached to using a non-allocating method.
		/// Optionally ignores the parent transform.
		/// Children of the object are acquired through a breadth-first search.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="component">Component whose hierarchy to search.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// List of components of type <typeparamref name="T"/> that game object's children have.
		/// </returns>
		public static List<T> GetComponentsInChildrenNonAlloc<T>(this Component component, bool ignoreCaller = false) where T : Component
		{
			return component.gameObject.GetComponentsInChildrenNonAlloc<T>(ignoreCaller);
		}
		
		/// <summary>
		/// Gets all components of specified type in in children of the game object
		/// component is attached to using a non-allocating method.
		/// Optionally ignores the parent transform.
		/// Children of the object are acquired through a breadth-first search.
		/// </summary>
		/// <param name="component">Component whose hierarchy to search.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// List of components of type <see cref="componentType"/> that game object's children have.
		/// </returns>
		public static List<Component> GetComponentsInChildrenNonAlloc(this Component component, Type componentType, bool ignoreCaller = false)
		{
			return component.gameObject.GetComponentsInChildrenNonAlloc(componentType, ignoreCaller);
		}

		/// <summary>
		/// Gets the first located component of type <typeparamref name="T"/> in parents of the game object component is attached to
		/// using a non-allocating method.
		/// Optionally ignores the transform on the calling game object.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="component">Component whose game object's parents to search.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// Component of type <typeparamref name="T"/> or null if component's upwards hierarchy doesn't contain component.
		/// </returns>
		public static T GetComponentInParentsNonAlloc<T>(this Component component, bool ignoreCaller = false) where T : Component
		{
			return component.gameObject.GetComponentInParentsNonAlloc<T>(ignoreCaller);
		}
		
		/// <summary>
		/// Gets the first located component of specified type in parents of the game object component is attached to
		/// using a non-allocating method.
		/// Optionally ignores the transform on the calling game object.
		/// </summary>
		/// <param name="component">Component whose game object's parents to search.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// Component of type <see cref="componentType"/> or null if component's upwards hierarchy doesn't contain component.
		/// </returns>
		public static Component GetComponentInParentsNonAlloc(this Component component, Type componentType, bool ignoreCaller = false)
		{
			return component.gameObject.GetComponentInParentsNonAlloc(componentType, ignoreCaller);
		}

		/// <summary>
		/// Gets all components of type <typeparamref name="T"/> in parents of the game object component is attached to. 
		/// Optionally ignores the transform on the calling object.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="component">Component whose game object's parents to search.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// List of components of type <typeparamref name="T"/> that component's upwards heirarchy contains.
		/// </returns>
		public static List<T> GetComponentsInParentsNonAlloc<T>(this Component component, bool ignoreCaller = false) where T : Component
		{
			return component.gameObject.GetComponentsInParentsNonAlloc<T>(ignoreCaller);
		}
		
		/// <summary>
		/// Gets all components of specified type in parents of the game object component is attached to. 
		/// Optionally ignores the transform on the calling object.
		/// </summary>
		/// <param name="component">Component whose game object's parents to search.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <returns>
		/// List of components of type <see cref="componentType"/> that component's upwards hierarchy contains.
		/// </returns>
		public static List<Component> GetComponentsInParentsNonAlloc(this Component component, Type componentType, bool ignoreCaller = false)
		{
			return component.gameObject.GetComponentsInParentsNonAlloc(componentType, ignoreCaller);
		}
		
		/// <summary>
		/// Gets the first located component of type <typeparamref name="T"/> in the hierarchy of a transform using a non-allocating method.
		/// Optionally ignores the calling transform.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="transform">Transform whose hierarchy to search.</param>
		/// <param name="searchChildrenFirst">Should children of the transform be searched before parents?</param>
		/// <param name="ignoreCaller">Should the calling transform be ignored?</param>
		/// <returns>
		/// Component of type <typeparamref name="T"/> or null if game object's hierarchy doesn't contain the component.
		/// </returns>
		public static T GetComponentInHierarchyNonAlloc<T>(this Transform transform, bool searchChildrenFirst = true,
														 bool ignoreCaller = false)
			where T : Component
		{
			return transform.gameObject.GetComponentInHierarchyNonAlloc<T>(searchChildrenFirst, ignoreCaller);
		}
		
		/// <summary>
		/// Gets the first located component of specified type in the hierarchy of a transform using a non-allocating method.
		/// Optionally ignores the calling transform.
		/// </summary>
		/// <param name="transform">Transform whose hierarchy to search.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <param name="searchChildrenFirst">Should children of the transform be searched before parents?</param>
		/// <param name="ignoreCaller">Should the calling transform be ignored?</param>
		/// <returns>
		/// Component of type <see cref="componentType"/> or null if game object's hierarchy doesn't contain the component.
		/// </returns>
		public static Component GetComponentInHierarchyNonAlloc(this Transform transform, Type componentType, bool searchChildrenFirst = true,
		                                                   bool ignoreCaller = false)
		{
			return transform.gameObject.GetComponentInHierarchyNonAlloc(componentType, searchChildrenFirst, ignoreCaller);
		}

		/// <summary>
		/// Gets all components of type <typeparamref name="T"/> in a transform's hierarchy (both parents and children). 
		/// Optionally ignores the calling transform.
		/// </summary>
		/// <typeparam name="T">Type of component to get.</typeparam>
		/// <param name="transform">Transform whose parents and children to search.</param>
		/// <param name="ignoreCaller">Should the calling transform be ignored?</param>
		/// <returns>
		/// List of components of type <typeparamref name="T"/> that transform's hierarchy contains.
		/// </returns>
		public static List<T> GetComponentsInHierarchyNonAlloc<T>(this Transform transform,
																 bool ignoreCaller = false) where T : Component
		{
			return transform.gameObject.GetComponentsInHierarchyNonAlloc<T>(ignoreCaller);
		}
		
		/// <summary>
		/// Gets all components of specified type in a transform's hierarchy (both parents and children). 
		/// Optionally ignores the calling transform.
		/// </summary>
		/// <param name="transform">Transform whose parents and children to search.</param>
		/// <param name="componentType">Type of component to get.</param>
		/// <param name="ignoreCaller">Should the calling transform be ignored?</param>
		/// <returns>
		/// List of components of type <see cref="componentType"/> that transform's hierarchy contains.
		/// </returns>
		public static List<Component> GetComponentsInHierarchyNonAlloc(this Transform transform, Type componentType, 
		                                                          bool ignoreCaller = false)
		{
			return transform.gameObject.GetComponentsInHierarchyNonAlloc(componentType, ignoreCaller);
		}

		#endregion

		#region Has

		/// <summary>
		/// Checks if the game object that this component is attached to has a component of specified type.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <typeparam name="T">Type of component to check.</typeparam>
		/// <returns>
		/// True if a component of target type exists, False otherwise.
		/// </returns>
		public static bool HasComponent<T>(this Component component) where T : Component
		{
			return GetComponentNonAlloc<T>(component) != null;
		}

		/// <summary>
		/// Checks if the game object that this component is attached to has a component of specified type.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <param name="componentType">Type of component to check.</param>
		/// <returns>
		/// True if a component of target type exists, False otherwise.
		/// </returns>
		public static bool HasComponent(this Component component, Type componentType)
		{
			return GetComponentNonAlloc(component, componentType) != null;
		}

		/// <summary>
		/// Checks if the game object that this component is attached to or any of its children have a component of specified type.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <typeparam name="T">Type of component to check.</typeparam>
		/// <returns>
		/// True if a component of target type exists, False otherwise.
		/// </returns>
		public static bool HasComponentInChildren<T>(this Component component, bool ignoreCaller = false) where T : Component
		{
			return GetComponentInChildrenNonAlloc<T>(component, ignoreCaller) != null;
		}

		/// <summary>
		/// Checks if the game object that this component is attached to or any of its children have a component of specified type.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <param name="componentType">Type of component to check.</param>
		/// <returns>
		/// True if a component of target type exists, False otherwise.
		/// </returns>
		public static bool HasComponentInChildren(this Component component, Type componentType, bool ignoreCaller = false)
		{
			return GetComponentInChildrenNonAlloc(component, componentType, ignoreCaller) != null;
		}

		/// <summary>
		/// Checks if the game object that this component is attached to or any of its parents have a component of specified type.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <typeparam name="T">Type of component to check.</typeparam>
		/// <returns>
		/// True if a component of target type exists, False otherwise.
		/// </returns>
		public static bool HasComponentInParents<T>(this Component component, bool ignoreCaller = false) where T : Component
		{
			return GetComponentInParentsNonAlloc<T>(component, ignoreCaller) != null;
		}

		/// <summary>
		/// Checks if the game object that this component is attached to or any of its parents have a component of specified type.
		/// </summary>
		/// <param name="component">Component.</param>
		/// <param name="ignoreCaller">Should the caller be ignored?</param>
		/// <param name="componentType">Type of component to check.</param>
		/// <returns>
		/// True if a component of target type exists, False otherwise.
		/// </returns>
		public static bool HasComponentInParents(this Component component, Type componentType, bool ignoreCaller = false)
		{
			return GetComponentInParentsNonAlloc(component, componentType, ignoreCaller) != null;
		}

		#endregion
	}
}