using Shopping.Cart.Common;

public interface IQuery
{

}

public interface IQueryHandler<TQuery, TResult>
{
	public TResult HandleQuery(TQuery query);
}