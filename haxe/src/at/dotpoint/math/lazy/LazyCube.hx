package at.dotpoint.math.lazy;

import at.dotpoint.core.dispatcher.event.Event;
import at.dotpoint.core.dispatcher.EventDispatcher;
import at.dotpoint.core.dispatcher.IEventDispatcher;
import at.dotpoint.core.evaluate.EvaluateObject;
import at.dotpoint.core.evaluate.event.EvaluateEvent;
import at.dotpoint.core.evaluate.IEvaluateObject;
import at.dotpoint.math.geom.Cube;
import at.dotpoint.math.MathUtil;
import at.dotpoint.math.vector.IVector3;

/**
 * ...
 * @author RK
 */
class LazyCube extends Cube implements IEvaluateObject
{

	/**
	 * whether or not the object needs to be validated
	 * true - validate() required; false - invalidate() possible
	 */
	public var isInvalidated(get, null):Bool;
	
	/**
	 * true - executeValidation is currently running, useful to ignore followup invalidations
	 */
	public var isCurrentlyValidating(get, null):Bool;
	
	/**
	 * 
	 */
	public var evaluate:IEvaluateObject;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( ?pivot:IVector3 = null, ?evaluate:IEvaluateObject )   
	{
		this.evaluate = evaluate != null ? evaluate : new EvaluateObject( null );	
		
		this.min = new LazyVector3( EvaluateObject.createSoloChangeObject( this.onChange ) );
		this.max = new LazyVector3( EvaluateObject.createSoloChangeObject( this.onChange ) );
		
		super( pivot );		
	}
	
	/**
	 * typical clone, but optional instance param which will be used
	 */
	override public function clone( ?output:Cube ):Cube 
	{
		if( output != null && !Std.is( output, LazyCube ) )
			throw "must provide LazyCube instance for clone";
		
		return super.clone( output != null ? output : new LazyCube() );
	}
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //
	
	/**
	 * 
	 * @param	event
	 */
	private function onChange( event:Event ):Void
	{
		this.invalidate();
	}
	
	// ************************************************************************ //
	// IEvaluateObject
	// ************************************************************************ //	
	
	/**
	 * 
	 * @return
	 */
	private function get_isInvalidated():Bool
	{
		return this.evaluate.isInvalidated;
	}
	
	/**
	 * 
	 * @return
	 */
	private function get_isCurrentlyValidating():Bool
	{
		return this.evaluate.isCurrentlyValidating;
	}
	
	// ------------------------- //
	
	/**
	 * marks the object as invalid requiring a validate() call
	 * dispatches EvaluateEvent.INVALIDATED and EvaluateEvent.CHANGED
	 */
	public function invalidate():Void
	{
		this.evaluate.invalidate();
	}
	
	/**
	 * marks the object as valid again makes a vinalidate() call possible
	 * dispatches EvaluateEvent.VALIDATED
	 */
	public function validate():Void
	{
		this.evaluate.validate();
	}
	
	// ----------------------------------------------------------------------- //
	// ----------------------------------------------------------------------- //
	
	/**
	 * 
	 * @param	event
	 */
	public function dispatch( event:Event ):Bool
	{
		return this.evaluate.dispatch( event );
	}
	
	/**
	 * 
	 * @param	type
	 * @param	call
	 */
	public function addListener( type:String, call:Event->Void ):Void
	{
		this.evaluate.addListener( type, call );
	}
	
	/**
	 * 
	 * @param	type
	 * @param	call
	 */
	public function removeListener( type:String, call:Event->Void ):Void
	{
		this.evaluate.removeListener( type, call );
	}
	
	/**
	 * 
	 * @param	type
	 * @return
	 */
	public function hasListener( type:String ):Bool
	{
		return this.evaluate.hasListener( type );
	}
	
	/**
	 * 
	 * @param	type
	 * @return
	 */
	public function clearListeners():Void
	{
		return this.evaluate.clearListeners();
	}
}